using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "backoffice");

            migrationBuilder.CreateTable(
                name: "Bedroom",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<bool>(type: "BIT", nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedroom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlackList",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    AddressDistrict = table.Column<string>(name: "Address_District", type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    AddressNumber = table.Column<string>(name: "Address_Number", type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    AddressState = table.Column<string>(name: "Address_State", type: "NVARCHAR(2)", maxLength: 2, nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    AddressZipCode = table.Column<string>(name: "Address_ZipCode", type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    AddressCode = table.Column<string>(name: "Address_Code", type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    AddressComplement = table.Column<string>(name: "Address_Complement", type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    AddressNotes = table.Column<string>(name: "Address_Notes", type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    Citizenship = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    Gender = table.Column<int>(type: "INT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NameFirstName = table.Column<string>(name: "Name_FirstName", type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    NameLastName = table.Column<string>(name: "Name_LastName", type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Nationality = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Obs = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    PhoneFullNumber = table.Column<string>(name: "Phone_FullNumber", type: "VARCHAR(16)", maxLength: 16, nullable: true),
                    PhoneVerificationIsVerified = table.Column<bool>(name: "Phone_Verification_IsVerified", type: "BIT", nullable: true),
                    PhoneVerificationCode = table.Column<string>(name: "Phone_Verification_Code", type: "CHAR(6)", maxLength: 6, nullable: true),
                    PhoneVerificationCodeExpireDate = table.Column<DateTime>(name: "Phone_Verification_CodeExpireDate", type: "DATETIME2", nullable: true),
                    Photo = table.Column<string>(type: "NVARCHAR", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNumber = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    DocumentType = table.Column<int>(type: "INT", nullable: false, defaultValue: 3),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "backoffice",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resident",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    BedroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EducationLevel = table.Column<int>(type: "INT", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    HealthInsurance = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false, defaultValue: "SUS"),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false),
                    MaritalStatus = table.Column<int>(type: "INT", nullable: false),
                    Mobility = table.Column<int>(type: "INT", nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    Profession = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    SUS = table.Column<long>(type: "BIGINT", nullable: false),
                    VoterRegCardNumber = table.Column<long>(type: "BIGINT", nullable: false),
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resident_Bedroom_BedroomId",
                        column: x => x.BedroomId,
                        principalSchema: "backoffice",
                        principalTable: "Bedroom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Resident_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "backoffice",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    EmailVerified = table.Column<bool>(type: "BIT", nullable: false),
                    EmailVerificationCode = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    EmailVerificationCodeExpireDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    PasswordHash = table.Column<string>(name: "Password_Hash", type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    PasswordExpired = table.Column<bool>(name: "Password_Expired", type: "BIT", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false),
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "backoffice",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occurrence",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "BIT", nullable: false),
                    OccurrenceDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2023, 3, 4, 20, 33, 41, 428, DateTimeKind.Utc).AddTicks(2541)),
                    OccurrenceType = table.Column<int>(type: "INT", nullable: false, defaultValue: 1),
                    ResidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occurrence_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "backoffice",
                        principalTable: "Resident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    EndDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "backoffice",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "backoffice",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_PersonId",
                schema: "backoffice",
                table: "Document",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrence_ResidentId",
                schema: "backoffice",
                table: "Occurrence",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resident_BedroomId",
                schema: "backoffice",
                table: "Resident",
                column: "BedroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Resident_PersonId",
                schema: "backoffice",
                table: "Resident",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                schema: "backoffice",
                table: "User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "backoffice",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "backoffice",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlackList",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Document",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Occurrence",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Resident",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "User",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Bedroom",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "backoffice");
        }
    }
}
