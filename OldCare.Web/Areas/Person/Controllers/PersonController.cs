using MediatR;
using Microsoft.AspNetCore.Authorization;
using OldCare.Web.Extensions;
using CreateRequest = OldCare.Contexts.PersonContext.UseCases.Create.Request;

namespace OldCare.Web.Areas.Person.Controllers;

[Area("Person")]
public class PersonController : Controller
{
    private readonly IMediator _mediator;

    #region Ctors

    public PersonController(IMediator mediator) => _mediator = mediator;

    #endregion

    #region Methods
    
    
    // TODO: Add create request
    [Authorize]
    [HttpGet("pessoas/adicionar")]
    public IActionResult Create() => View();

    [Authorize]
    [HttpPost("pessoas/adicionar")]
    public async Task<IActionResult> Create(CreateRequest request)
    {
        try
        {
            var result = await _mediator.Send(request);

            if(result.IsSuccess) 
                return RedirectToAction(nameof(AddressStepFromCreate), "Person", request);

            ModelState.AddResultErrors(result.Errors);

            return View(request);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);

            return View(request);
        }
    }

    [Authorize]
    [HttpGet("pessoas/adicionar/endereco")]
    public IActionResult AddressStepFromCreate(CreateRequest request)
    {
         return View(request);
    }

    [Authorize]
    [HttpGet("pessoas/adicionar/filiacao-e-contato")]
    public IActionResult FinalStepFromCreate() => View();

    [Authorize]
    [HttpGet("pessoas")]
    public IActionResult Index() => View();

    #endregion
}