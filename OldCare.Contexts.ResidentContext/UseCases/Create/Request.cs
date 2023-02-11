using MediatR;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.ResidentContext.UseCases.Create;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public Guid PersonId { get; set; } = new();
    public DateTime AdmissionDate { get; set; } = DateTime.UtcNow;
    public EEducationLevel EducationLevel { get; set; }
    public string HealthInsurance { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public EMaritalStatus MaritalStatus { get; set; }
    public EMobility Mobility { get; set; }
    public string Note { get; set; } = string.Empty;
    public string Profession { get; set; }
    public long SUS { get; set; }
    public long VoterRegCardNumber { get; set; }
    public string returnUrl { get; set; } = string.Empty;
}