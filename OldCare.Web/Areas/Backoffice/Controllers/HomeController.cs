using Microsoft.AspNetCore.Mvc;

namespace Balta.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}