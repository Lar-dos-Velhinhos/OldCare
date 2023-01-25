using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UCCreate = OldCare.Contexts.ResidentContext.UseCases.Create;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.API.Controllers;

[ApiController]
[Route("api/vi/Controller")]
public class ResidentController
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


}