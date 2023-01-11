using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Capacity = table.Column<byte>(type: "TINYINT", nullable: false),
                    Gender = table.Column<bool>(type: "BIT", nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false)
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
                    AddressZipCode = table.Column<string>(name: "Address_ZipCode", type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    AddressNumber = table.Column<string>(name: "Address_Number", type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    AddressComplement = table.Column<string>(name: "Address_Complement", type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    AddressDistrict = table.Column<string>(name: "Address_District", type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    AddressState = table.Column<string>(name: "Address_State", type: "NVARCHAR(2)", maxLength: 2, nullable: false),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    AddressCode = table.Column<string>(name: "Address_Code", type: "NVARCHAR(160)", maxLength: 160, nullable: true),
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
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false)
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
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => new { x.PersonId, x.Id });
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
                    BedroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    Father = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    HealthInsurance = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    MaritalStatus = table.Column<byte>(type: "TINYINT", nullable: false),
                    Mobility = table.Column<byte>(type: "TINYINT", nullable: false),
                    Mother = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Profession = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    EducationLevel = table.Column<byte>(type: "TINYINT", nullable: false),
                    SUS = table.Column<int>(type: "INT", nullable: false),
                    VoterRegCardNumber = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resident_Bedroom_BedroomId",
                        column: x => x.BedroomId,
                        principalSchema: "backoffice",
                        principalTable: "Bedroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TrackerCreatedAt = table.Column<DateTime>(name: "Tracker_CreatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerUpdatedAt = table.Column<DateTime>(name: "Tracker_UpdatedAt", type: "SMALLDATETIME", nullable: false),
                    TrackerNotes = table.Column<string>(name: "Tracker_Notes", type: "NVARCHAR(1024)", maxLength: 1024, nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
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
                name: "UserRole",
                schema: "backoffice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true),
                    EndDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: true)
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
                name: "Resident",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Bedroom",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "User",
                schema: "backoffice");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "backoffice");
        }
    }
}
