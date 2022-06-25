namespace OldCare.Web.Areas.Identity.Controllers;

[Area("Identity")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
