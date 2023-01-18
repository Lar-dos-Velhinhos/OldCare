using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OldCare.Contexts.SharedContext.UseCases;
using UCCreate = OldCare.Contexts.PersonContext.UseCases.Create;
using UCGet = OldCare.Contexts.PersonContext.UseCases.Get;
using UCDelete = OldCare.Contexts.PersonContext.UseCases.Delete;
using UCModify = OldCare.Contexts.PersonContext.UseCases.Modify;

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
    /// Soft delete person
    /// </summary>
    /// <param name="id">Person global unique identifier</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpDelete("delete/{id}")]
    public async Task<BaseResponse<UCDelete.ResponseData>> DeleteAsync(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new UCDelete.Request(){Id = id});
            return result;
        }
        catch (Exception e)
        {
            return new BaseResponse<UCDelete.ResponseData>(e.Message, "BF270861", 400);
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

    /// <summary>
    /// Modify active person address
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPut("modify-address")]
    public async Task<BaseResponse<UCModify.ResponseData>> ModifyAddress(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new UCModify.Request() { PersonId = id });
            return result;
        }
        catch(Exception e)
        {
            return new BaseResponse<UCModify.ResponseData>(e.Message, "43D089E3", 400);
        }
    }
}