using Microsoft.AspNetCore.Mvc;

namespace Oldcare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
[Route("Pessoas")]
public class PersonController : Controller
{
    [Route("Principal")]
    public IActionResult Index() => View();
    
    [Route("Cadastrar")]
    public IActionResult Create() => View();
}