using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.API.Migrations
{
    /// <inheritdoc />
    public partial class FeatHangFire : Migration
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
                defaultValue: new DateTime(2023, 5, 22, 20, 10, 15, 663, DateTimeKind.Utc).AddTicks(5177),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 3, 4, 20, 33, 41, 428, DateTimeKind.Utc).AddTicks(2541));
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
                defaultValue: new DateTime(2023, 3, 4, 20, 33, 41, 428, DateTimeKind.Utc).AddTicks(2541),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 5, 22, 20, 10, 15, 663, DateTimeKind.Utc).AddTicks(5177));
        }
    }
}
