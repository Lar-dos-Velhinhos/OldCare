using System.Diagnostics;

namespace OldCare.Web.Areas.Identity.Controllers;

[Area("Identity")]
[AllowAnonymous]
public class RegisterController : Controller
{
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly IUserStore<IdentityUser<Guid>> _userStore;
    private readonly IUserEmailStore<IdentityUser<Guid>> _emailStore;
    private readonly ILogger<RegisterModel> _logger;
    private readonly IEmailSender _emailSender;

    [TempData]
    public string StatusMessage { get; set; }

    public RegisterController(
        UserManager<IdentityUser<Guid>> userManager,
        IUserStore<IdentityUser<Guid>> userStore,
        SignInManager<IdentityUser<Guid>> signInManager,
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

    [AllowAnonymous]
    public IActionResult Register() => View();

    [HttpPost]
    [AllowAnonymous]
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

        password = PasswordHasher.Hash(password);

        var user = new IdentityUser<Guid>
        { 
            Id = Guid.NewGuid(),
            UserName = email,
            Email = email,
            PasswordHash = password
        };

        await _userStore.SetUserNameAsync(user, email, CancellationToken.None);
        //await _emailStore.SetEmailAsync(user, email, CancellationToken.None);
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
                return RedirectToPage("RegisterConfirmation", new { email = user.Email, returnUrl = returnUrl });
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
