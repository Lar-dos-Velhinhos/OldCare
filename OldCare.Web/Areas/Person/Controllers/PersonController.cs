using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OldCare.Web.Areas.Person.Controllers;

[Area("Person")]
public class PersonController : Controller
{
    #region Ctors

    public PersonController()
    {
    }

    #endregion

    #region Methods
    
    [Authorize]
    [HttpGet("pessoas/adicionar")]
    public IActionResult Create() => View();
    
    [Authorize]
    [HttpGet("pessoas/adicionar/endereco")]
    public IActionResult AddressStepFromCreate() => View();

    [Authorize]
    [HttpGet("pessoas")]
    public IActionResult Index() => View();

    #endregion
}