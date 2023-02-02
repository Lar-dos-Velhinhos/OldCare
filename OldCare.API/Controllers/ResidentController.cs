using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OldCare.Contexts.SharedContext.UseCases;
using UCCreate = OldCare.Contexts.ResidentContext.UseCases.Create;
using UCGet = OldCare.Contexts.ResidentContext.UseCases.Get;

namespace OldCare.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ResidentController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResidentController(
        IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Create a new resident
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("new-resident")]
    public async Task<BaseResponse<UCCreate.ResponseData>> CreateAsync(UCCreate.Request request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return result;
        }
        catch (Exception e)
        {
            return new BaseResponse<UCCreate.ResponseData>(e.Message, "C9F78602");
        }
    }

    /// <summary>
    /// Get all existing and not deleted residents
    /// </summary>
    /// <param name="request">Used to specify amount of registers will be returned and amount of registers will be ignored</param>
    /// <returns>List of residents</returns>
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
            return new BaseResponse<UCGet.ResponseData>(e.Message, "D26168A2");
        }
    }
}