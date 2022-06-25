namespace OldCare.Web.Areas.Identity.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<LoginModel> _logger;
    private readonly IEmailSender _emailSender;

    public string ReturnUrl { get; private set; }
    public bool RememberMe { get; private set; }

    public LoginController(
        SignInManager<IdentityUser> signInManager,
        ILogger<LoginModel> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginModel model)
    {
        model.ReturnUrl ??= Url.Content("~/");

        if (!ModelState.IsValid)
            return View();

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
        if (result.Succeeded)
        {
            _logger.LogInformation("User logged in");
            return LocalRedirect(model.ReturnUrl);
        }
        if (result.RequiresTwoFactor)
        {
            return RedirectToPage("./LoginWith2fa", new { ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }
        if (result.IsLockedOut)
        {
            _logger.LogWarning("User account locked out.");
            return RedirectToPage("./Lockout");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Tentativa inválida de login.");
            return View();
        }
    }

    [HttpGet]
    public async Task<IActionResult> LoginWith2faAsync(bool rememberMe, string returnUrl = null)
    {
        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

        if (user == null)
            throw new InvalidOperationException($"Não foi possível carreagar a autenticação de dois fatores para o usuário.");

        ReturnUrl = returnUrl;
        RememberMe = rememberMe;

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
    {
        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
        if (user == null)
            throw new InvalidOperationException($"Não foi possível carreagar a autenticação de dois fatores para o usuário.");

        ReturnUrl = returnUrl;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeModel model)
    {
        if (!ModelState.IsValid)
            return View();

        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
        if (user == null)
            throw new InvalidOperationException($"Não foi possível carreagar a autenticação de dois fatores para o usuário.");

        var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

        var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

        var userId = await _userManager.GetUserIdAsync(user);

        if (result.Succeeded)
        {
            _logger.LogInformation("User with ID '{UserId}' logged in with a recovery code.", user.Id);
            return LocalRedirect(ReturnUrl ?? Url.Content("~/"));
        }
        if (result.IsLockedOut)
        {
            _logger.LogWarning("User account locked out.");
            return RedirectToPage("./Lockout");
        }
        else
        {
            _logger.LogWarning("Invalid recovery code entered for user with ID '{UserId}' ", user.Id);
            ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> LoginWith2faAsync(LoginWith2faModel model)
    {
        if (!ModelState.IsValid)
            return View();

        model.ReturnUrl = ReturnUrl ?? Url.Content("~/");

        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
        if (user == null)
            throw new InvalidOperationException($"Não foi possível carreagar a autenticação de dois fatores para o usuário..");

        var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, model.RememberMe, model.RememberMachine);

        var userId = await _userManager.GetUserIdAsync(user);

        if (result.Succeeded)
        {
            _logger.LogInformation($"User with ID '{user.Id}' logged in with 2fa.");
            return LocalRedirect(ReturnUrl);
        }
        else if (result.IsLockedOut)
        {
            _logger.LogWarning($"User with ID '{user.Id}' account locked out.");
            return RedirectToPage("./Lockout");
        }
        else
        {
            _logger.LogWarning($"Invalid authenticator code entered for user with ID '{user.Id}'.");
            ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> LogoutAsync(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User logged out.");

        if (String.IsNullOrEmpty(returnUrl))
            return RedirectToAction();

        return LocalRedirect(returnUrl);
    }

    [HttpGet]
    public IActionResult Lockout() => View();

    [HttpGet]
    public async Task<IActionResult> ConfirmEmailChangeAsyn(ConfirmEmailChangeModel model)
    {
        if (model.UserId == null || model.Email == null || model.Code == null)
            return RedirectToPage("/Index");

        var user = await _userManager.FindByIdAsync(model.UserId);
        if (user == null)
            return NotFound($"Não foi encontrado um usuário com o Id '{model.UserId}'.");

        model.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Code));
        var result = await _userManager.ChangeEmailAsync(user, model.Email, model.Code);
        if (!result.Succeeded)
        {
            model.StatusMessage = "Erro ao modificar o e-mail.";
            return View();
        }

        var setUserNameResult = await _userManager.SetUserNameAsync(user, model.Email);
        if (!setUserNameResult.Succeeded)
        {
            model.StatusMessage = "Erro ao modificar o nome de usuário.";
            return View();
        }

        await _signInManager.RefreshSignInAsync(user);
        model.StatusMessage = "Obrigado por confirmar a mudança de e-mail.";
        return View();
    }

    [HttpGet]
    public IActionResult ResendEmailConfirmationModel() => View();

    [HttpPost]
    public async Task<IActionResult> ResendEmailConfirmationModelAsync(ResendEmailConfirmationModel model)
    {
        if (!ModelState.IsValid)
            return View();

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Email de confirmação enviado. Por favor verifique a caixa de entrada.");
            return View();
        }

        var userId = await _userManager.GetUserIdAsync(user);
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var callbackUrl = Url.Page(
            "/Account/ConfirmEmail",
            pageHandler: null,
            values: new { userId = userId, code = code },
            protocol: Request.Scheme);
        await _emailSender.SendEmailAsync(
            model.Email,
            "Confirme seu e-mail",
            $"Uma nova conta foi criada com este endereço de e - mail, para confirmar visite: <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        ModelState.AddModelError(string.Empty, "Email de confirmação enviado. Por favor verifique a caixa de entrada.");
        return View();
    }

    [HttpGet]
    public IActionResult ResetPassword(string code = null)
    {
        if (code == null)
            return BadRequest("O código é necessário para mudar a senha.");
        else
        {
            ResetPasswordModel model = new ()
            {
                Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
            };
            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> ResetPasswordAsync(ResetPasswordModel model)
    {
        if (!ModelState.IsValid)
            return View();

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
            return RedirectToPage("./ResetPasswordConfirmation");

        var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
        if (result.Succeeded)
            return RedirectToPage("./ResetPasswordConfirmation");

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                return RedirectToPage("./ForgotPasswordConfirmation");

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { area = "Identity", code },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(
                model.Email,
                "Reset Password",
                $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            return RedirectToPage("./ForgotPasswordConfirmation");
        }

        return View();
    }

    [HttpGet]
    public IActionResult ForgotPasswordConfirmation() => View();
}
