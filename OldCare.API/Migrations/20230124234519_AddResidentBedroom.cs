using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.API.Migrations
{
    /// <inheritdoc />
    public partial class AddResidentBedroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Father",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.RenameColumn(
                name: "Mother",
                schema: "backoffice",
                table: "Resident",
                newName: "Tracker_Notes");

            migrationBuilder.AlterColumn<long>(
                name: "VoterRegCardNumber",
                schema: "backoffice",
                table: "Resident",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<long>(
                name: "SUS",
                schema: "backoffice",
                table: "Resident",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                schema: "backoffice",
                table: "Resident",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(160)",
                oldMaxLength: 160);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                schema: "backoffice",
                table: "Resident",
                type: "NVARCHAR(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "Mobility",
                schema: "backoffice",
                table: "Resident",
                type: "INT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatus",
                schema: "backoffice",
                table: "Resident",
                type: "INT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<string>(
                name: "HealthInsurance",
                schema: "backoffice",
                table: "Resident",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "SUS",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(160)",
                oldMaxLength: 160);

            migrationBuilder.AlterColumn<int>(
                name: "EducationLevel",
                schema: "backoffice",
                table: "Resident",
                type: "INT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureDate",
                schema: "backoffice",
                table: "Resident",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AdmissionDate",
                schema: "backoffice",
                table: "Resident",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "backoffice",
                table: "Resident",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "Resident",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "Resident",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                schema: "backoffice",
                table: "Bedroom",
                type: "INT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TINYINT");

            migrationBuilder.CreateTable(
                name: "Occurrence",
                schema: "backoffice",
                columns: table => new
                {
                    ResidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccurrenceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OccurrenceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrence", x => new { x.ResidentId, x.Id });
                    table.ForeignKey(
                        name: "FK_Occurrence_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "backoffice",
                        principalTable: "Resident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occurrence",
                schema: "backoffice");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.RenameColumn(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "Resident",
                newName: "Mother");

            migrationBuilder.AlterColumn<int>(
                name: "VoterRegCardNumber",
                schema: "backoffice",
                table: "Resident",
                type: "INT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AlterColumn<int>(
                name: "SUS",
                schema: "backoffice",
                table: "Resident",
                type: "INT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                schema: "backoffice",
                table: "Resident",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(160)",
                oldMaxLength: 160,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                schema: "backoffice",
                table: "Resident",
                type: "NVARCHAR(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Mobility",
                schema: "backoffice",
                table: "Resident",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<byte>(
                name: "MaritalStatus",
                schema: "backoffice",
                table: "Resident",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<string>(
                name: "HealthInsurance",
                schema: "backoffice",
                table: "Resident",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(160)",
                oldMaxLength: 160,
                oldDefaultValue: "SUS");

            migrationBuilder.AlterColumn<byte>(
                name: "EducationLevel",
                schema: "backoffice",
                table: "Resident",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureDate",
                schema: "backoffice",
                table: "Resident",
                type: "DATETIME2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AdmissionDate",
                schema: "backoffice",
                table: "Resident",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AddColumn<string>(
                name: "Father",
                schema: "backoffice",
                table: "Resident",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte>(
                name: "Capacity",
                schema: "backoffice",
                table: "Bedroom",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");
        }
    }
}
