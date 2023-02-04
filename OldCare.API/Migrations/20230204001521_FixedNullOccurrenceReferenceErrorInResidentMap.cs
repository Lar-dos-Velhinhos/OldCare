using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.API.Migrations
{
    /// <inheritdoc />
    public partial class FixedNullOccurrenceReferenceErrorInResidentMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OccurrenceDate",
                schema: "backoffice",
                table: "Occurrence",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 4, 0, 15, 20, 558, DateTimeKind.Utc).AddTicks(1163),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 3, 23, 59, 55, 254, DateTimeKind.Utc).AddTicks(1176));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OccurrenceDate",
                schema: "backoffice",
                table: "Occurrence",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 23, 59, 55, 254, DateTimeKind.Utc).AddTicks(1176),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 2, 4, 0, 15, 20, 558, DateTimeKind.Utc).AddTicks(1163));
        }
    }
}
