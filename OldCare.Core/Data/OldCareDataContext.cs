﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OldCare.Core.Data.Mapping;
using OldCare.Core.Entities;
using System;

namespace OldCare.Core.Data;
public class OldCareDataContext : DbContext
{
    public OldCareDataContext(DbContextOptions options) : base(options) { }

    public DbSet<Bedroom> Bedrooms { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Occurrence> Occurrences { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionItem> PrescriptionItens { get; set; }
    public DbSet<Resident> Residents { get; set; }
    public DbSet<ResidentResponsible> Resident_Responsibles { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BedroomMap());
        modelBuilder.ApplyConfiguration(new MedicationMap());
        modelBuilder.ApplyConfiguration(new OccurrenceMap());
        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new PrescriptionMap());
        modelBuilder.ApplyConfiguration(new PrescriptionItemMap());
        modelBuilder.ApplyConfiguration(new ResidentMap());
        modelBuilder.ApplyConfiguration(new ResponsibleMap());
        modelBuilder.ApplyConfiguration(new ResidentResponsibleMap());

        #region AspNetIdentityOthers

        modelBuilder.Entity<IdentityUserClaim<Guid>>(b =>
        {
            b.ToTable("AspNetUserClaims");
            b.HasKey(uc => uc.Id);
            b.Property(u => u.ClaimType).HasMaxLength(255);
            b.Property(u => u.ClaimValue).HasMaxLength(255);
        });

        modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
        {
            b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            b.Property(l => l.LoginProvider).HasMaxLength(128);
            b.Property(l => l.ProviderKey).HasMaxLength(128);
            b.ToTable("AspNetUserLogins");
            b.Property(u => u.ProviderDisplayName).HasMaxLength(255);
        });

        modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
        {
            b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            b.Property(t => t.LoginProvider).HasMaxLength(120);
            b.Property(t => t.Name).HasMaxLength(180);
            b.ToTable("AspNetUserTokens");
        });

        modelBuilder.Entity<IdentityRoleClaim<Guid>>(b =>
        {
            b.HasKey(rc => rc.Id);
            b.ToTable("AspNetRoleClaims");
            b.Property(u => u.ClaimType).HasMaxLength(255);
            b.Property(u => u.ClaimValue).HasMaxLength(255);
        });

        #endregion
    }
}