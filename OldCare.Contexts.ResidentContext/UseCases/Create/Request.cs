using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;
using OldCare.Contexts.SharedContext.ValueObjects;

namespace OldCare.Contexts.ResidentContext.UseCases.Create;

public class Request : IRequest<BaseResponse<ResponseData>>
{
    public Person Person { get; set; } = new();

    public DateTime AdmissionDate { get; set; } = DateTime.UtcNow;

    public Bedroom Bedroom { get; set; } = new();

    public EEducationLevel EducationLevel { get; set; }

    public DateTime DepartureDate { get; set; } = DateTime.UtcNow;

    public string HealthInsurance { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

    public EMaritalStatus MaritalStatus { get; set; }

    public EMobility Mobility { get; set; }

    public string Note { get; set; } = string.Empty;

    public List<Occurrence> Occurrences { get; set; }

    public string Profession { get; set; }

    public long SUS { get; set; }

    public long VoterRegCardNumber { get; set; }
}