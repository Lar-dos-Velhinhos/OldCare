namespace OldCare.Web.Areas.Identity.Controllers
{
    public class AccountManagerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ChangePasswordModel> _logger;

        public AccountManagerController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        private async Task<AccountManagerIndexModel> LoadUserAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            AccountManagerIndexModel model = new() {
                Username = userName,
                PhoneNumber = phoneNumber
            };

            return model;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Não foi encontrado um usuário com o Id '{_userManager.GetUserId(User)}'.");

            AccountManagerIndexModel model = await LoadUserAsync(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AccountManagerIndexModel mode)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Não foi encontrado um usuário com o Id '{_userManager.GetUserId(User)}'.");

            AccountManagerIndexModel model = await LoadUserAsync(user);

            if (!ModelState.IsValid)
                return View(model);

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    model.StatusMessage = "Um erro inesperado ocorreu ao tentar salvar o telefone.";
                    return RedirectToAction();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            model.StatusMessage = "Seu perfil foi atualizado.";
            return RedirectToAction();
        }

        [HttpGet]
        public async Task<IActionResult> ChangePasswordAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Não foi encontrado um usuário com o Id: '{_userManager.GetUserId(User)}'.");

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
                return RedirectToPage("./SetPassword");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Não foi encontrado um usuário com o Id: '{_userManager.GetUserId(User)}'.");

            var changePasswordResult =
                await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            model.StatusMessage = "Your password has been changed.";

            return RedirectToAction();
        }

        private async Task<EmailModel> LoadEmailAsync(IdentityUser user, EmailModel model)
        {
            var email = await _userManager.GetEmailAsync(user);
            EmailModel response = new();
            response.Email = email;
            response.NewEmail = model.NewEmail;
            response.IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return response;
        }

        [HttpGet]
        public async Task<IActionResult> EmailAsync(EmailModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Não foi encontrado um usuário com o Id '{_userManager.GetUserId(User)}'.");

            await LoadEmailAsync(user, model);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmailAsync(EmailModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            if (!ModelState.IsValid)
            {
                await LoadEmailAsync(user, model);
                return View();
            }

            if (model.NewEmail != model.Email)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, email = model.NewEmail, code = code },
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(
                    model.NewEmail,
                    "Confirmar e-mail",
                    $"Uma conta foi vinculada a este endereço de e-mail, para confirmar visite <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>OldCare</a>.");

                model.StatusMessage = "Confirmation link to change email sent. Please check your email.";
                return RedirectToAction();
            }

            model.StatusMessage = "Seu e-mail não foi modificado.";
            return RedirectToAction();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync(EmailModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Não foi encontrado um usuário com este Id '{_userManager.GetUserId(User)}'.");

            EmailModel response = new();

            if (!ModelState.IsValid)
            {
                response = await LoadEmailAsync(user, model);
                return View(response);
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new {area = "Identity", userId = userId, code = code},
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirme seu e-mail",
                $"Uma conta foi vinculada a este endereço de e-mail, para confirmar visite <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>OldCare</a>.");

            model.StatusMessage = "E-mail de verificação enviado. Por favor verifique a caixa de entrada.";
            return RedirectToAction();
        }

        [HttpGet]
        public async Task<IActionResult> DeletePersonalDataAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Não foi encontrado um usuário com o Id: '{_userManager.GetUserId(User)}'.");

            DeletePersonalDataModel model = new();
            model.RequirePassword = await _userManager.HasPasswordAsync(user);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePersonalDataAsync(DeletePersonalDataModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Não foi encontrado um usuário com o Id: '{_userManager.GetUserId(User)}'.");

            model.RequirePassword = await _userManager.HasPasswordAsync(user);
            if (model.RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    ModelState.AddModelError(string.Empty, "Senha incorreta.");
                    return View();
                }
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
                throw new InvalidOperationException($"Um erro inesperado aconteceu ao deletar o usuário.");

            await _signInManager.SignOutAsync();

            _logger.LogInformation("Usuário com id '{UserId}' se excluiu.", userId);

            return Redirect("~/");
        }
    }
}