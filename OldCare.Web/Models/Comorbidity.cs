namespace OldCare.Web.Models
{
    public class Comorbidity : Entity
    {
        public Guid ResidentId { get; set; }
        public virtual ResidentModel? Resident { get; set; }
        public string Description  { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Note { get; set; }
        public string? Restriction { get; set; }
        public DateTime StartDate { get; set; }
    }
}
