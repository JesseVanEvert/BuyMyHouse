using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyMyHouse.DAL.Migrations
{
    public partial class AddedRelationShipsBetweenApplicationAndHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HouseID",
                table: "Application",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_HouseID",
                table: "Application",
                column: "HouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_House_HouseID",
                table: "Application",
                column: "HouseID",
                principalTable: "House",
                principalColumn: "HouseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_House_HouseID",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_HouseID",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "HouseID",
                table: "Application");
        }
    }
}
