using MediatR;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.PersonContext.UseCases.Modify;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    #region Public properties
    
    public Guid PersonId { get; set; }
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Complement { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    
    #endregion
}