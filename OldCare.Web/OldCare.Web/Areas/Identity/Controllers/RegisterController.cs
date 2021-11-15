using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using OldCare.Web.Models;
using SecureIdentity.Password;

namespace OldCare.Web.Areas.Identity.Controllers;

public class RegisterController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;
    private readonly ILogger<RegisterModel> _logger;
    private readonly IEmailSender _emailSender;

    [TempData]
    public string StatusMessage { get; set; }

    public RegisterController(
        UserManager<IdentityUser> userManager,
        IUserStore<IdentityUser> userStore,
        SignInManager<IdentityUser> signInManager,
        ILogger<RegisterModel> logger,
        IEmailSender emailSender)
    {
        _userManager = userManager;
        _userStore = userStore;
        //_emailStore = userManager.GetEmailAsync();
        _signInManager = signInManager;
        _logger = logger;
        _emailSender = emailSender;
    }

    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromForm] string email,
        [FromQuery] string returnUrl = "~/")
    {
        if (!ModelState.IsValid)
            return View();

        var password = PasswordGenerator.Generate(
            length: 16,
            includeSpecialChars: true,
            upperCase: true);

        var user = new IdentityUser { 
            Id = Guid.NewGuid().ToString(),
            UserName = email,
            Email = email };

        await _userStore.SetUserNameAsync(user, email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            _logger.LogInformation($"A new account for with password has been created: {user.Email}");

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Confirme seu e-mail",
                $"Uma nova conta foi criada com este endereço de e-mail, para confirmar visite: <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>OldCare</a>.");

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                return RedirectToPage("RegisterConfirmation", new { email = user.Email, returnUrl = returnUrl });
            }
            else
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View();
    }

    public async Task<IActionResult> RegisterConfirmationAsync(RegisterConfirmationModel model)
    {
        if (model.Email == null)
        {
            return RedirectToPage("/Index");
        }
        model.ReturnUrl = model.ReturnUrl ?? Url.Content("~/");

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return NotFound($"Não foi encontardo um usuário com o e-mail: '{model.Email}'.");
        }

        model.Email = model.Email;
        // Once you add a real email sender, you should remove this code that lets you confirm the account
        model.DisplayConfirmAccountLink = true;
        if (model.DisplayConfirmAccountLink)
        {
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
#pragma warning disable CS8601 // Possible null reference assignment.
            model.EmailConfirmationUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code, returnUrl = model.ReturnUrl },
                protocol: Request.Scheme);
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmEmailAsync(string userId, string code)
    {
        if (userId == null || code == null)
            return RedirectToPage("/Index");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound($"Não foi encontrado um usuário com o Id: '{userId}'.");

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);
        StatusMessage = result.Succeeded ? "Obrigado por confirmar a sua conta." : "Erro ao confirmar o e-mail.";
        return View();
    }
}
