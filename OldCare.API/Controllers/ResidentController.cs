using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OldCare.Contexts.SharedContext.Enums;
using LogService = OldCare.Contexts.SharedContext.Services.Log.Contracts.IService;
using OldCare.Contexts.SharedContext.UseCases;
using UCCreate = OldCare.Contexts.ResidentContext.UseCases.Create;
using UCDelete = OldCare.Contexts.ResidentContext.UseCases.Delete;
using UCGet = OldCare.Contexts.ResidentContext.UseCases.Get;
using UCGetDetails = OldCare.Contexts.ResidentContext.UseCases.Details;
using UCModify = OldCare.Contexts.ResidentContext.UseCases.Modify;

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
    [HttpDelete("delete/{residentId}")]
    public async Task<BaseResponse<UCDelete.ResponseData>> Delete(Guid residentId)
    {
        try
        {
            var result = await _mediator.Send(new UCDelete.Request(residentId));
            return result;
        }
        catch (Exception ex)
        {
            await _logService.LogAsync(ELogType.Error, $"❌ Não foi possível remover o residente.", "0A9D357F", ex.Message);
            return new BaseResponse<UCDelete.ResponseData>("Não foi possível remover o residente.", "0A9D357F");
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

    /// <summary>
    /// Fetch a existing resident and not deleted with all details
    /// </summary>
    /// <param name="request">Used to specify register that will be returned</param>
    /// <returns>A resident</returns>
    [AllowAnonymous]
    [HttpGet("get-details/{id}")]
    public async Task<BaseResponse<UCGetDetails.ResponseData>> GetDetailsAsync(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new UCGetDetails.Request(id));
            return result;
        }
        catch (Exception exception)
        {

            return new BaseResponse<UCGetDetails.ResponseData>(exception.Message, "D6A0CB78", 400);
        }
    }

    /// <summary>
    /// Update active resident data
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPut("modify/{id}")]
    public async Task<BaseResponse<UCModify.ResponseData>> Modify(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new UCModify.Request(id));
            return result;
        }
        catch (Exception exception)
        {
            await _logService.LogAsync(ELogType.Error, "❌ Não foi possível editar os dados do residente.", "EDF18767", exception.Message);
            return new BaseResponse<UCModify.ResponseData>("Não foi possível editar os dados do residente", "EDF18767", 400);
        }
    }

    #endregion
}