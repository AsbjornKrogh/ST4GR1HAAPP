using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class PationIdAsStringAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_Patient_patientCPR",
                table: "TecnicalSpecs");

            migrationBuilder.DropIndex(
                name: "IX_TecnicalSpecs_patientCPR",
                table: "TecnicalSpecs");

            migrationBuilder.DropColumn(
                name: "patientCPR",
                table: "TecnicalSpecs");

            migrationBuilder.AlterColumn<string>(
                name: "CPR",
                table: "TecnicalSpecs",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_CPR",
                table: "TecnicalSpecs",
                column: "CPR");

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_Patient_CPR",
                table: "TecnicalSpecs",
                column: "CPR",
                principalTable: "Patient",
                principalColumn: "CPR",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_Patient_CPR",
                table: "TecnicalSpecs");

            migrationBuilder.DropIndex(
                name: "IX_TecnicalSpecs_CPR",
                table: "TecnicalSpecs");

            migrationBuilder.AlterColumn<int>(
                name: "CPR",
                table: "TecnicalSpecs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");

            migrationBuilder.AddColumn<string>(
                name: "patientCPR",
                table: "TecnicalSpecs",
                type: "varchar(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_patientCPR",
                table: "TecnicalSpecs",
                column: "patientCPR");

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_Patient_patientCPR",
                table: "TecnicalSpecs",
                column: "patientCPR",
                principalTable: "Patient",
                principalColumn: "CPR",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
