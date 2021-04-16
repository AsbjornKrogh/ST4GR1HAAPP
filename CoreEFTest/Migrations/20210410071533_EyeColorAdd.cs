using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class EyeColorAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.AddColumn<string>(
              name: "EyeColor",
              table: "Patient",
              type: "varchar(10)",
              maxLength: 10,
              nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "Patient");
        }
    }
}
