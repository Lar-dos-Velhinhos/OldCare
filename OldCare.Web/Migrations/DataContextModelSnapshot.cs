﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OldCare.Data;

#nullable disable

namespace OldCare.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.BlackList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("BlackList", (string)null);
                });

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Citizenship")
                        .HasMaxLength(160)
                        .HasColumnType("NVARCHAR(160)");

                    b.Property<bool>("Gender")
                        .HasColumnType("BIT");

                    b.Property<string>("Obs")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Photo")
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR(40)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("BIT");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("EndDate");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("RoleId");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("StartDate");

                    b.Property<Guid>("UserId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.BlackList", b =>
                {
                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("BlackListId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("VARCHAR(120)")
                                .HasColumnName("Email");

                            b1.HasKey("BlackListId");

                            b1.ToTable("BlackList");

                            b1.WithOwner()
                                .HasForeignKey("BlackListId");
                        });

                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Tracker", "Tracker", b1 =>
                        {
                            b1.Property<Guid>("BlackListId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("SMALLDATETIME")
                                .HasColumnName("CreatedAt");

                            b1.Property<string>("Notes")
                                .HasMaxLength(1024)
                                .HasColumnType("nvarchar(1024)")
                                .HasColumnName("Notes");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("SMALLDATETIME")
                                .HasColumnName("UpdatedAt");

                            b1.HasKey("BlackListId");

                            b1.ToTable("BlackList");

                            b1.WithOwner()
                                .HasForeignKey("BlackListId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Tracker")
                        .IsRequired();
                });

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.Person", b =>
                {
                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Tracker", "Tracker", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("SMALLDATETIME");

                            b1.Property<string>("Notes")
                                .IsRequired()
                                .HasMaxLength(160)
                                .HasColumnType("NVARCHAR(160)");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("SMALLDATETIME");

                            b1.HasKey("PersonId");

                            b1.ToTable("Person");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(160)
                                .HasColumnType("NVARCHAR(160)");

                            b1.Property<string>("Code")
                                .HasMaxLength(160)
                                .HasColumnType("NVARCHAR(160)");

                            b1.Property<string>("Complement")
                                .HasMaxLength(160)
                                .HasColumnType("NVARCHAR(160)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(160)
                                .HasColumnType("NVARCHAR(160)");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasMaxLength(160)
                                .HasColumnType("NVARCHAR(160)");

                            b1.Property<string>("Notes")
                                .HasMaxLength(160)
                                .HasColumnType("NVARCHAR(160)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("NVARCHAR(20)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("NVARCHAR(2)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(160)
                                .HasColumnType("NVARCHAR(160)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("NVARCHAR(20)");

                            b1.HasKey("PersonId");

                            b1.ToTable("Person");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsMany("OldCare.Contexts.SharedContext.ValueObjects.Document", "Documents", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonId", "Id");

                            b1.ToTable("Document");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("NVARCHAR(60)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("NVARCHAR(60)");

                            b1.HasKey("PersonId");

                            b1.ToTable("Person");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FullNumber")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("VARCHAR(16)");

                            b1.HasKey("PersonId");

                            b1.ToTable("Person");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");

                            b1.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Verification", "Verification", b2 =>
                                {
                                    b2.Property<Guid>("PhonePersonId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasMaxLength(6)
                                        .HasColumnType("CHAR(6)");

                                    b2.Property<DateTime>("CodeExpireDate")
                                        .HasColumnType("DATETIME2");

                                    b2.Property<bool>("IsVerified")
                                        .HasColumnType("BIT");

                                    b2.HasKey("PhonePersonId");

                                    b2.ToTable("Person");

                                    b2.WithOwner()
                                        .HasForeignKey("PhonePersonId");
                                });

                            b1.Navigation("Verification")
                                .IsRequired();
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Documents");

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Phone");

                    b.Navigation("Tracker")
                        .IsRequired();
                });

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.User", b =>
                {
                    b.HasOne("OldCare.Contexts.AccountContext.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Tracker", "Tracker", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("SMALLDATETIME");

                            b1.Property<string>("Notes")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .HasColumnType("NVARCHAR(1024)");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("SMALLDATETIME");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Email", "Username", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("VARCHAR(120)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Verification", "Verification", b2 =>
                                {
                                    b2.Property<Guid>("EmailUserId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasMaxLength(8)
                                        .HasColumnType("CHAR(8)")
                                        .HasColumnName("EmailVerificationCode");

                                    b2.Property<DateTime>("CodeExpireDate")
                                        .HasColumnType("DATETIME2")
                                        .HasColumnName("EmailVerificationCodeExpireDate");

                                    b2.Property<bool>("IsVerified")
                                        .HasColumnType("BIT")
                                        .HasColumnName("EmailVerified");

                                    b2.HasKey("EmailUserId");

                                    b2.ToTable("User");

                                    b2.WithOwner()
                                        .HasForeignKey("EmailUserId");
                                });

                            b1.Navigation("Verification")
                                .IsRequired();
                        });

                    b.OwnsOne("OldCare.Contexts.SharedContext.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("Expired")
                                .HasColumnType("BIT");

                            b1.Property<string>("Hash")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("VARCHAR(120)");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Tracker")
                        .IsRequired();

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("OldCare.Contexts.AccountContext.Entities.UserRole", b =>
                {
                    b.HasOne("OldCare.Contexts.AccountContext.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OldCare.Contexts.AccountContext.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
