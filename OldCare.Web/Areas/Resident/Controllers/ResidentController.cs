using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OldCare.Data;
using HomeRequest = OldCare.Contexts.AccountContext.UseCases.ListResidents.Request;

namespace OldCare.Web.Areas.Resident.Controllers;

[Area("Resident")]
public class ResidentController : Controller
{
    private readonly IMediator _mediator;

    #region Ctors

    public ResidentController(IMediator mediator)
        => _mediator = mediator;

    #endregion
    
    #region Home

    [Authorize]
    [HttpGet("residentes")]
    public IActionResult Home([FromServices] DataContext context)
        => View(new HomeRequest());

    // [HttpPost("residentes")]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> Home(
    //     Contexts.AccountContext.UseCases.Edit.Request request)
    // {
    //     request.Email = User?.Identity?.Name ?? string.Empty;
    //     try
    //     {
    //         var result = await _mediator.Send(request);
    //         if (result.IsSuccess)
    //         {
    //             ViewBag.Success = result.Data?.Message ?? string.Empty;
    //             return View(request);
    //         }
    //
    //         ModelState.AddResultErrors(result.Errors);
    //         return View(request);
    //     }
    //     catch (Exception ex)
    //     {
    //         ModelState.AddModelError("Error", ex.Message);
    //         return View(request);
    //     }
    // }

    #endregion
}