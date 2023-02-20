using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.API.Migrations
{
    /// <inheritdoc />
    public partial class initialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                schema: "backoffice",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                schema: "backoffice",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OccurrenceDate",
                schema: "backoffice",
                table: "Occurrence",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 19, 22, 49, 24, 590, DateTimeKind.Utc).AddTicks(2062),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 6, 22, 39, 37, 896, DateTimeKind.Utc).AddTicks(2864));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                schema: "backoffice",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                schema: "backoffice",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OccurrenceDate",
                schema: "backoffice",
                table: "Occurrence",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 6, 22, 39, 37, 896, DateTimeKind.Utc).AddTicks(2864),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 19, 22, 49, 24, 590, DateTimeKind.Utc).AddTicks(2062));
        }
    }
}
