﻿using MediatR;
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
    
    [Authorize]
    [HttpGet("pessoas")]
    public IActionResult Index() => View();

    [Authorize]
    [HttpGet("pessoas/adicionar")]
    public IActionResult GetNewPerson(CreateRequest request)
    {
        foreach (var key in ModelState.Keys)
            ModelState.ClearValidationState(key);

        return View(request);
    }

    [Authorize]
    [HttpPost("pessoas/adicionar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostNewPerson(CreateRequest request)
    {
        try
        {
            var result = await _mediator.Send(request);

            if(result.IsSuccess) 
                return RedirectToAction(nameof(GetAddressStepFromCreate), "Person", request);
            
            ModelState.AddResultErrors(result.Errors);

            return RedirectToAction(nameof(GetNewPerson), request);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);

            return RedirectToAction(nameof(GetNewPerson), request);
        }
    }

    [Authorize]
    [HttpGet("pessoas/adicionar/endereco")]
    public IActionResult GetAddressStepFromCreate(CreateRequest request)
    {
        return View(request);
    }

    [Authorize]
    [HttpPost("pessoas/adicionar/endereco")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostAddressStepFromCreate(CreateRequest request, string submitButton)
    {
        if(submitButton == "return")
            return RedirectToAction(nameof(GetNewPerson), "Person", request);
        
        try
        {
            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return RedirectToAction(nameof(GetFinalStepFromCreate), "Person", request);
            
            ModelState.AddResultErrors(result.Errors);

            return RedirectToAction(nameof(GetAddressStepFromCreate), request);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);
            return RedirectToAction(nameof(GetAddressStepFromCreate), request);
        }
         
    }

    [Authorize]
    [HttpGet("pessoas/adicionar/filiacao-e-contato")]
    public IActionResult GetFinalStepFromCreate(CreateRequest request) => View("FinalStepFromCreate", request);

    [Authorize]
    [HttpPost("pessoas")]
    public async Task<IActionResult> PostFinalStepFromCreate(CreateRequest request)
    {
        try
        {
            var result = await _mediator.Send(request);

            if(result.IsSuccess) 
                return RedirectToAction(nameof(Index), "Person");
            
            ModelState.AddResultErrors(result.Errors);

            return RedirectToAction(nameof(GetFinalStepFromCreate), request);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("Error", ex.Message);

            return RedirectToAction(nameof(GetFinalStepFromCreate), request);
        }
    }

    #endregion
}