using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class EarSideEnumAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ear",
                table: "EarCast");

            migrationBuilder.AddColumn<int>(
                name: "EarSide",
                table: "EarCast",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarSide",
                table: "EarCast");

            migrationBuilder.AddColumn<string>(
                name: "Ear",
                table: "EarCast",
                type: "char(1)",
                nullable: false,
                defaultValue: "");
        }
    }
}
