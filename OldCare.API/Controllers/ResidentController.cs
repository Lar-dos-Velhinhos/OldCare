using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OldCare.Contexts.PersonContext.UseCases.Modify;
using Request = OldCare.Contexts.PersonContext.UseCases.Get.Request;

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
    public async Task<BaseResponse<ResponseData>> CreateAsync(Request request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return result;
        }
        catch (Exception e)
        {
            return new BaseResponse<ResponseData>(e.Message, "C9F78602");
        }

       
    }


}