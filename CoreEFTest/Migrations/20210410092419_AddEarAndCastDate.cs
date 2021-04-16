using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class AddEarAndCastDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CastDate",
                table: "EarCast",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
               name: "Ear",
               table: "EarCast",
               type: "char(1)",
               nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CastDate",
                table: "EarCast");

            migrationBuilder.DropColumn(
                name: "Ear",
                table: "EarCast");
        }
    }
}
