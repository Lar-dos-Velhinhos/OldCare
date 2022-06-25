using Microsoft.AspNetCore.Mvc;

namespace Balta.Web.Controllers;

public class HomeController : Controller
{
    [HttpGet("politicas/cancelamento")]
    public IActionResult CancelPolicy() => View();
    
    public IActionResult Index() => View();
    
    [HttpGet("como-funciona")]
    public IActionResult HowWorks() => View();

    [HttpGet("politicas/privacidade")]
    public IActionResult PrivacyPolicy() => View();

    [HttpGet("social")]
    public IActionResult Social() => View();

    [HttpGet("politicas/uso")]
    public IActionResult UsePolicy() => View();
}
