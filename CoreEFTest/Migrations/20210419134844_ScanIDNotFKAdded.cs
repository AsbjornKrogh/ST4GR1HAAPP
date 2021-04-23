using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class ScanIDNotFKAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_RawEarScans_ScanID",
                table: "TecnicalSpecs");

            migrationBuilder.DropIndex(
                name: "IX_TecnicalSpecs_ScanID",
                table: "TecnicalSpecs");

            migrationBuilder.RenameColumn(
                name: "HAinfo",
                table: "TecnicalSpecs",
                newName: "HAGenerelSpec");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HAGenerelSpec",
                table: "TecnicalSpecs",
                newName: "HAinfo");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_ScanID",
                table: "TecnicalSpecs",
                column: "ScanID");

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_RawEarScans_ScanID",
                table: "TecnicalSpecs",
                column: "ScanID",
                principalTable: "RawEarScans",
                principalColumn: "ScanID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
