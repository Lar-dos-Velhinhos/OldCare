using OldCare.Core.Entities;

namespace OldCare.Core.Data;

public class AppDbContext : DbContext
{
    public DbSet<Bedroom> Bedrooms { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Occurrence> Occurrences { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
    public DbSet<Product> Products { get; set; }    
    public DbSet<Resident> Residents { get; set; }
    public DbSet<ResidentResponsible> ResidentResponsibles { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=127.0.0.1;Database=oldcare;User ID=sa;Password=1q2w3e4r@#$");
}

