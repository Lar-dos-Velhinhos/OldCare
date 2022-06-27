using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlackList",
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
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Address_Street = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Address_Number = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Address_Complement = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    Address_District = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Address_City = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Address_State = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: false),
                    Address_Country = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    Address_Code = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    Address_Notes = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    Citizenship = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: true),
                    Gender = table.Column<bool>(type: "BIT", nullable: false),
                    Name_FirstName = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Name_LastName = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Obs = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    Phone_FullNumber = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: true),
                    Phone_Verification_IsVerified = table.Column<bool>(type: "BIT", nullable: true),
                    Phone_Verification_Code = table.Column<string>(type: "CHAR(6)", maxLength: 6, nullable: true),
                    Phone_Verification_CodeExpireDate = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    Photo = table.Column<string>(type: "NVARCHAR", nullable: true),
                    Tracker_CreatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Tracker_UpdatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Tracker_Notes = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
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
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    EmailVerified = table.Column<bool>(type: "BIT", nullable: false),
                    EmailVerificationCode = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    EmailVerificationCodeExpireDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Password_Hash = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    Password_Expired = table.Column<bool>(type: "BIT", nullable: false),
                    Tracker_CreatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Tracker_UpdatedAt = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Tracker_Notes = table.Column<string>(type: "NVARCHAR(1024)", maxLength: 1024, nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
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
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlackList");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
