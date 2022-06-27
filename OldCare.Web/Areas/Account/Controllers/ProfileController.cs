using System.Security.Claims;
using OldCare.Data;
using OldCare.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OldCare.Web.Areas.Account.Controllers;

[Area("Account")]
public class ProfileController : Controller
{
    private readonly IMediator _mediator;

    #region Ctors

    public ProfileController(IMediator mediator)
        => _mediator = mediator;

    #endregion

    #region Methods

    #region Change Email

    [HttpGet("minha-conta/email")]
    public IActionResult ChangeEmail()
        => View();

    [HttpPost("minha-conta/email")]
    public async Task<IActionResult> ChangeEmail(
        [Bind] Contexts.AccountContext.UseCases.ChangeEmail.Request request)
    {
        request.OldEmail = User.Identity?.Name ?? string.Empty;

        try
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Redirect("~/sair");

            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }
    }

    #endregion

    #region Change Password

    [Authorize]
    [HttpGet("minha-conta/senha")]
    public IActionResult ChangePassword() => View(new Contexts.AccountContext.UseCases.ChangePassword.Request
    {
        Email = User?.Identity?.Name ?? string.Empty
    });

    [Authorize]
    [HttpPost("minha-conta/senha")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(
        [Bind] Contexts.AccountContext.UseCases.ChangePassword.Request request)
    {
        request.Email = User?.Identity?.Name ?? string.Empty;

        try
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Redirect("~/sair");

            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }
    }

    #endregion

    #region Create

    [HttpGet("comecar")]
    public IActionResult Create(string? returnUrl)
        => View(new Contexts.AccountContext.UseCases.Create.Request { ReturnUrl = returnUrl });

    [HttpPost("comecar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind] Contexts.AccountContext.UseCases.Create.Request request)
    {
        request.GoogleReCaptchaResponse = Request.Form["g-recaptcha-response"];
        try
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return RedirectToAction(nameof(Login));

            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }
    }

    #endregion

    #region Edit

    [Authorize]
    [HttpGet("minha-conta/edit")]
    public async Task<IActionResult> Edit([FromServices] DataContext context)
    {
        var email = User.Identity?.Name ?? string.Empty;
        var request = await context
            .Users
            .AsNoTracking()
            .Where(x => x.Username.Address == email)
            .Select(x => new Contexts.AccountContext.UseCases.Edit.Request
            {
                FirstName = x.Person.Name.FirstName,
                LastName = x.Person.Name.LastName,
                Phone = x.Person.Phone == null ? string.Empty : x.Person.Phone.FullNumber,
                Documents = x.Person.Documents,
                Email = x.Username.Address,
                BirthDate = x.Person.BirthDate
            })
            .FirstOrDefaultAsync();

        return View(request);
    }

    [HttpPost("minha-conta/edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        Contexts.AccountContext.UseCases.Edit.Request request)
    {
        request.Email = User?.Identity?.Name ?? string.Empty;
        try
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                ViewBag.Success = result.Data?.Message ?? string.Empty;
                return View(request);
            }

            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }
    }

    #endregion

    #region Home
    
    [Authorize]
    [HttpGet("minha-conta")]
    public async Task<IActionResult> Home() => View();

    // [HttpPost("minha-conta")]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Home() => View();

    #endregion

    #region Login

    [HttpGet("entrar")]
    public IActionResult Login(string? returnUrl)
    {
        if (!@User.Identity.IsAuthenticated)
            return View(new Contexts.AccountContext.UseCases.Authenticate.Request { ReturnUrl = returnUrl });

        return RedirectToAction("Home");
    }

    [HttpPost("entrar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(
        [FromServices] IMediator mediator,
        Contexts.AccountContext.UseCases.Authenticate.Request request)
    {
        OldCare.Contexts.SharedContext.UseCases.BaseResponse<Contexts.AccountContext.UseCases.Authenticate.ResponseData>
            result;
        try
        {
            result = await mediator.Send(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }

        if (!result.IsSuccess)
        {
            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }

        if (result.Data is null)
        {
            ModelState.AddModelError("Login", "Falha ao carregar dados da conta");
            return View(request);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, request.Email),
            new("FullName", result.Data.Name),
            new("Id", result.Data.Id),
            // new(ClaimTypes.Role, "premium"), // TODO: Preencher os roles
        };

        var claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.Now.AddHours(8),
            IssuedUtc = DateTimeOffset.UtcNow
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return string.IsNullOrEmpty(request.ReturnUrl)
            ? Redirect("~/minha-conta")
            : Redirect(request.ReturnUrl);
    }

    #endregion

    #region Logout

    [HttpGet("sair")]
    public async Task<IActionResult> Logout(string? returnUrl)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return string.IsNullOrEmpty(returnUrl)
            ? Redirect("~/entrar")
            : Redirect(returnUrl);
    }

    #endregion

    #region Request Password Reset Code

    [HttpGet("/minha-conta/senha/restaurar")]
    public IActionResult RequestPasswordResetCode() =>
        View(new Contexts.AccountContext.UseCases.RequestPasswordResetCode.Request());

    [HttpPost("/minha-conta/senha/restaurar")]
    public async Task<IActionResult> RequestPasswordResetCode(
        [Bind] Contexts.AccountContext.UseCases.RequestPasswordResetCode.Request request)
    {
        request.GoogleReCaptchaResponse = Request.Form["g-recaptcha-response"];
        try
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                ViewBag.Success = "Enviamos um novo código de restauração de senha no seu E-mail!";
                return View(request);
            }

            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }
    }

    #endregion

    #region Resend Email Verification Code

    [HttpGet("minha-conta/email/verificar/reenviar")]
    public IActionResult ResendEmailVerificationCode() =>
        View(new Contexts.AccountContext.UseCases.ResendEmailVerificationCode.Request());

    [HttpPost("minha-conta/email/verificar/reenviar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResendEmailVerificationCode(
        [Bind] Contexts.AccountContext.UseCases.ResendEmailVerificationCode.Request request)
    {
        request.GoogleReCaptchaResponse = Request.Form["g-recaptcha-response"];
        try
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return View(request);

            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }
    }

    #endregion

    #region Reset Password

    [HttpGet("/minha-conta/senha/restaurar/{verificationCode?}")]
    public IActionResult ResetPassword(
        [FromRoute] string? verificationCode = null,
        [FromQuery] string? returnUrl = null)
    {
        var model = new Contexts.AccountContext.UseCases.ResetPassword.Request
        {
            VerificationCode = verificationCode,
            ReturnUrl = returnUrl
        };
        model.LoadDataFromVerificationCode();
        return View(model);
    }

    [HttpPost("/minha-conta/senha/restaurar/{verificationCode?}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(
        [Bind] Contexts.AccountContext.UseCases.ResetPassword.Request request,
        [FromRoute] string? verificationCode = null)
    {
        request.GoogleReCaptchaResponse = Request.Form["g-recaptcha-response"];
        try
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Redirect("~/entrar");

            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }
    }

    #endregion

    #region Verify Email

    [HttpGet("minha-conta/email/verificar/{hash?}")]
    public IActionResult VerifyEmail(
        [FromRoute] string? hash = null,
        [FromQuery] string? returnUrl = null)
    {
        var model = new Contexts.AccountContext.UseCases.VerifyEmail.Request
        {
            Hash = hash,
            ReturnUrl = returnUrl
        };
        model.LoadDataFromHash();

        return View(model);
    }

    [HttpPost("minha-conta/email/verificar/{hash?}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> VerifyEmail(
        [Bind] Contexts.AccountContext.UseCases.VerifyEmail.Request request,
        [FromRoute] string? hash = null)
    {
        request.GoogleReCaptchaResponse = Request.Form["g-recaptcha-response"];
        try
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return string.IsNullOrEmpty(request.ReturnUrl)
                    ? RedirectToAction(nameof(Login))
                    : Redirect(request.ReturnUrl);

            ModelState.AddResultErrors(result.Errors);
            return View(request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return View(request);
        }
    }

    #endregion

    #endregion
}