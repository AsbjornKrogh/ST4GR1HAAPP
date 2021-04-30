using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class UpdatedContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpecs_HAGenerelSpecID",
                table: "TecnicalSpecs");

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpecs_HAGenerelSpecID",
                table: "TecnicalSpecs",
                column: "HAGenerelSpecID",
                principalTable: "GeneralSpecs",
                principalColumn: "HAGeneralSpecID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpecs_HAGenerelSpecID",
                table: "TecnicalSpecs");

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpecs_HAGenerelSpecID",
                table: "TecnicalSpecs",
                column: "HAGenerelSpecID",
                principalTable: "GeneralSpecs",
                principalColumn: "HAGeneralSpecID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
