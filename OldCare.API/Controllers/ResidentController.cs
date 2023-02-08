using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OldCare.Contexts.SharedContext.Enums;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;
using OldCare.Contexts.SharedContext.UseCases;
using UCCreate = OldCare.Contexts.ResidentContext.UseCases.Create;
using UCDelete = OldCare.Contexts.ResidentContext.UseCases.Delete;
using UCGet = OldCare.Contexts.ResidentContext.UseCases.Get;

namespace OldCare.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ResidentController : ControllerBase
{
    #region Private Properties

    private readonly LogService _logService;
    private readonly IMediator _mediator;
    
    #endregion
    
    #region Public Constructors
    
    public ResidentController(LogService logService, IMediator mediator)
        => (_logService, _mediator) = (logService, mediator);
    
    #endregion

    #region Public Methods

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
    /// Delete an existent Resident by your id
    /// </summary>
    /// <param name="request"></param>
    /// <returns>If success return successfull message, if dont return request data.</returns>
    [AllowAnonymous]
    [HttpDelete]
    public async Task<BaseResponse<UCDelete.ResponseData>> Delete(UCDelete.Request request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return result;
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ELogType.Error, $"❌ {request.ResidentId} - Não foi possível marcar o residente como deletado.", "0A9D357F", ex.Message);
            return new BaseResponse<UCDelete.ResponseData>($"{request.ResidentId} - Não foi possível marcar o residente como deletado.", "0A9D357F");
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

    #endregion
}