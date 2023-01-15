using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UCCreate = OldCare.Contexts.AccountContext.UseCases.Create;
using UCGet = OldCare.Contexts.AccountContext.UseCases.Get;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonController(
        IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Create a new person
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("new-person")]
    public async Task<BaseResponse<UCCreate.ResponseData>> CreateAsync(UCCreate.Request request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return result;
        }
        catch (Exception e)
        {
            return new BaseResponse<UCCreate.ResponseData>(e.Message, "85398A03");
        }
    }

    /// <summary>
    /// Get all existing and not deleted people
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("get-all")]
    public async Task<BaseResponse<UCGet.ResponseData>> GetAllAsync(UCGet.Request request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return result;
        }
        catch (Exception e)
        {
            return new BaseResponse<UCGet.ResponseData>(e.Message, "CDC03992", 400);
        }
    }

    [AllowAnonymous]
    [HttpDelete("delete/{id}")]
    public async Task<BaseResponse<Contexts.AccountContext.UseCases.Delete.ResponseData>> DeleteAsync(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new Contexts.AccountContext.UseCases.Delete.Request(){Id = id});
            return result;
        }
        catch (Exception e)
        {
            return new BaseResponse<Contexts.AccountContext.UseCases.Delete.ResponseData>(e.Message, "BF270861", 400);
        }
    }
}