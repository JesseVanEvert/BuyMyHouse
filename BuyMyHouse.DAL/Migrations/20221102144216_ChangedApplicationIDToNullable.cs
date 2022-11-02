using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyMyHouse.DAL.Migrations
{
    public partial class ChangedApplicationIDToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Application_ApplicationID",
                table: "Person");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationID",
                table: "Person",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Application_ApplicationID",
                table: "Person",
                column: "ApplicationID",
                principalTable: "Application",
                principalColumn: "ApplicationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Application_ApplicationID",
                table: "Person");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationID",
                table: "Person",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Application_ApplicationID",
                table: "Person",
                column: "ApplicationID",
                principalTable: "Application",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
