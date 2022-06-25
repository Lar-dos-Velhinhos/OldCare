namespace OldCare.Web.ViewModels.Backoffice.Resident
{
    public class CreateResidentViewModel : Entity
    {
        [Display(Name ="Pessoa")]
        public Guid PersonId { get; set; }
        public virtual Person? Person { get; set; }

        [Display(Name ="Quarto")]
        public Guid BedroomId { get; set; }
        public virtual Bedroom? Bedroom { get; set; }

        [Display(Name = "Data de Entrada")]
        public DateTime AdmissionDate { get; set; }

        [Display(Name = "Data de Saída")]
        public DateTime? DepartureDate { get; set; }

        [Display(Name = "Pai")]
        public string? Father { get; set; }

        [Display(Name = "Plano de Saúde")]
        public string? HealthInsurance { get; set; }

        [Display(Name = "Estado Civil")]
        public EMaritalStatus MaritalStatus { get; set; }

        [Display(Name = "Mobilidade")]
        public EMobility Mobility { get; set; }

        [Display(Name = "Mãe")]
        public string? Mother { get; set; }

        [Display(Name = "Observação")]
        public string? Note { get; set; }

        [Display(Name = "Profissão")]
        public string? Profession { get; set; }

        [Display(Name = "Nível Educacional")]
        public EEducationLevel EducationLevel { get; set; }

        [Display(Name = "Número do Cartão do SUS")]
        public long SUS { get; set; }

        [Display(Name = "Título de Eleitor")]
        public long VoterRegCardNumber { get; set; }
        public List<Bedroom> Bedrooms { get; set; }
        public List<Person> Persons { get; set; }
    }
}
