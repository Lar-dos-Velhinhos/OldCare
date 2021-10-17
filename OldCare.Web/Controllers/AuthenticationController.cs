using Microsoft.AspNetCore.Mvc;

namespace OldCare.Web.Controllers;
public class AuthenticationController : Controller
{
    public IActionResult Login() => View();
}
