using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyMyHouse.DAL.Migrations
{
    public partial class AddedDateTimeToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_House_HouseID",
                table: "Application");

            migrationBuilder.AlterColumn<Guid>(
                name: "HouseID",
                table: "Application",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedAt",
                table: "Application",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Application_House_HouseID",
                table: "Application",
                column: "HouseID",
                principalTable: "House",
                principalColumn: "HouseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_House_HouseID",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "AppliedAt",
                table: "Application");

            migrationBuilder.AlterColumn<Guid>(
                name: "HouseID",
                table: "Application",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_House_HouseID",
                table: "Application",
                column: "HouseID",
                principalTable: "House",
                principalColumn: "HouseID");
        }
    }
}
