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

    public IActionResult Index() => Index();

    #endregion
}