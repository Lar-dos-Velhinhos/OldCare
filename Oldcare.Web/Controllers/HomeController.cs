using Microsoft.AspNetCore.Mvc;

namespace OldCare.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
