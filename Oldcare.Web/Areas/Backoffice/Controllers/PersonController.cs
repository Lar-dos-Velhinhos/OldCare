using Microsoft.AspNetCore.Mvc;

namespace Oldcare.Web.Areas.Backoffice.Controllers;

[Area("Backoffice")]
[Route("Pessoas")]
public class PersonController : Controller
{
    [Route("Principal")]
    public IActionResult Index() => View();
    
    [Route("Cadastrar-Inicio")]
    public IActionResult CreateStart() => View();
    
    [Route("Cadastrar-Final")]
    public IActionResult CreateEnd() => View();
}