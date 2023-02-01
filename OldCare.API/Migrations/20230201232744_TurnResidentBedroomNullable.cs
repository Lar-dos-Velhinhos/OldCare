using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldCare.API.Migrations
{
    /// <inheritdoc />
    public partial class TurnResidentBedroomNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Bedroom_BedroomId",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Person_PersonId",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                schema: "backoffice",
                table: "Resident",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BedroomId",
                schema: "backoffice",
                table: "Resident",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Bedroom_BedroomId",
                schema: "backoffice",
                table: "Resident",
                column: "BedroomId",
                principalSchema: "backoffice",
                principalTable: "Bedroom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Person_PersonId",
                schema: "backoffice",
                table: "Resident",
                column: "PersonId",
                principalSchema: "backoffice",
                principalTable: "Person",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Bedroom_BedroomId",
                schema: "backoffice",
                table: "Resident");

            migrationBuilder.DropForeignKey(
                name: "FK_Resident_Person_PersonId",
                schema: "backoffice",
                table: "Resident");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "BedroomId",
                schema: "backoffice",
                table: "Resident",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_Bedroom_BedroomId",
                schema: "backoffice",
                table: "Resident",
                column: "BedroomId",
                principalSchema: "backoffice",
                principalTable: "Bedroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
