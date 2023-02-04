using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrackerToOccurrence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Person_PersonId",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occurrence",
                schema: "backoffice",
                table: "Occurrence");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "UserRole",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "UserRole",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "UserRole",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "Role",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "Role",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "Role",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                schema: "backoffice",
                table: "Resident",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OccurrenceType",
                schema: "backoffice",
                table: "Occurrence",
                type: "INT",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OccurrenceDate",
                schema: "backoffice",
                table: "Occurrence",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 23, 59, 55, 254, DateTimeKind.Utc).AddTicks(1176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "backoffice",
                table: "Occurrence",
                type: "NVARCHAR(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "backoffice",
                table: "Occurrence",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "backoffice",
                table: "Occurrence",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "Occurrence",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "Occurrence",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "Occurrence",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "Bedroom",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "Bedroom",
                type: "NVARCHAR(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "Bedroom",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occurrence",
                schema: "backoffice",
                table: "Occurrence",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrence_ResidentId",
                schema: "backoffice",
                table: "Occurrence",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Person_PersonId",
                schema: "backoffice",
                table: "Resident",
                column: "PersonId",
                principalSchema: "backoffice",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Person_PersonId",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occurrence",
                schema: "backoffice",
                table: "Occurrence");

            migrationBuilder.DropIndex(
                name: "IX_Occurrence_ResidentId",
                schema: "backoffice",
                table: "Occurrence");

            migrationBuilder.DropColumn(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "backoffice",
                table: "Occurrence");

            migrationBuilder.DropColumn(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "Occurrence");

            migrationBuilder.DropColumn(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "Occurrence");

            migrationBuilder.DropColumn(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "Occurrence");

            migrationBuilder.DropColumn(
                name: "Tracker_CreatedAt",
                schema: "backoffice",
                table: "Bedroom");

            migrationBuilder.DropColumn(
                name: "Tracker_Notes",
                schema: "backoffice",
                table: "Bedroom");

            migrationBuilder.DropColumn(
                name: "Tracker_UpdatedAt",
                schema: "backoffice",
                table: "Bedroom");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                schema: "backoffice",
                table: "Resident",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "OccurrenceType",
                schema: "backoffice",
                table: "Occurrence",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OccurrenceDate",
                schema: "backoffice",
                table: "Occurrence",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 3, 23, 59, 55, 254, DateTimeKind.Utc).AddTicks(1176));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "backoffice",
                table: "Occurrence",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "backoffice",
                table: "Occurrence",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occurrence",
                schema: "backoffice",
                table: "Occurrence",
                columns: new[] { "ResidentId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Person_PersonId",
                schema: "backoffice",
                table: "Resident",
                column: "PersonId",
                principalSchema: "backoffice",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
