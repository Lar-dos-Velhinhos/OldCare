using MediatR;
using OldCare.Contexts.ResidentContext.Entities;
using OldCare.Contexts.SharedContext.Entities;
using OldCare.Contexts.SharedContext.Enums;
using OldCare.Contexts.SharedContext.UseCases;

namespace OldCare.Contexts.ResidentContext.UseCases.Modify;

public class Request : IRequest<BaseResponse<ResponseData>>
{
	#region Public Constructors

	public Request(Guid residentId) => ResidentId = residentId;

	#endregion


	#region Public Properties	


	#region Region Address
	public string AddressNumber { get; set; } = string.Empty;
	public string AddressCity { get; set; } = string.Empty;
	public string AddressCode { get; set; } = string.Empty;
	public string AddressComplement { get; set; } = string.Empty;
	public string AddressCountry { get; set; } = string.Empty;
	public string AddressDistrict { get; set; } = string.Empty;
	public string AddressNotes { get; set; } = string.Empty;
	public string AddressState { get; set; } = string.Empty;
	public string AddressStreet { get; set; } = string.Empty;
	public string AddressZipCode { get; set; } = string.Empty;

    #endregion

    #region Region Personal Data

    public Guid PersonId { get; set; }
    public DateTime BirthDate { get; set; }
	public string Citizenship { get; set; } = null!;
	public string? FatherName { get; set; }
	public EGender Gender { get; set; }
	public string? MotherName { get; set; }
	public string Nationality { get; set; } = "BR";
	public string? Obs { get; set; }

    #endregion

    #region Bedroom Data

    public Guid BedroomId { get; set; }
	public int BedroomCapacity { get; set; }
	public bool BedroomGender { get; set; }
	public int BedroomNumber { get; set; }

	#endregion

	#region Occurrence Data

	public string OccurrenceDescription { get; set; } = string.Empty;
	public bool OccurrenceIsDeleted { get; set; }
	public DateTime OccurrenceDate { get; set; }
	public EOccurrenceType OccurrenceType { get; set; }


	#endregion

	public Guid ResidentId { get; set; }	
	public DateTime AdmissionDate { get; set; } = DateTime.UtcNow;
	public EEducationLevel EducationLevel { get; set; }
	public string HealthInsurance { get; set; } = string.Empty;
	public bool IsDeleted { get; set; }
	public EMaritalStatus MaritalStatus { get; set; }
	public EMobility Mobility { get; set; }
	public string Note { get; set; } = string.Empty;
	public List<Occurrence>? Occurrences { get; set; }
	public string Profession { get; set; } = string.Empty;
	public long SUS { get; set; }
	public long VoterRegCardNumber { get; set; }
	public string returnUrl { get; set; } = string.Empty;

	#endregion
}
