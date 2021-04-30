using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class GeneralSpecAddCPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EarCast_Patient_PatientCPR",
                table: "EarCast");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSpecs_StaffLogin_StaffID",
                table: "GeneralSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarPrints_StaffLogin_StaffID",
                table: "RawEarPrints");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarPrints");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarScans_StaffLogin_StaffID",
                table: "RawEarScans");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarScans_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarScans");

            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_Patient_CPR",
                table: "TecnicalSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_StaffLogin_StaffID",
                table: "TecnicalSpecs");

            migrationBuilder.AddColumn<string>(
                name: "CPR",
                table: "GeneralSpecs",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSpecs_CPR",
                table: "GeneralSpecs",
                column: "CPR");

            migrationBuilder.AddForeignKey(
                name: "FK_EarCast_Patient_PatientCPR",
                table: "EarCast",
                column: "PatientCPR",
                principalTable: "Patient",
                principalColumn: "CPR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSpecs_Patient_CPR",
                table: "GeneralSpecs",
                column: "CPR",
                principalTable: "Patient",
                principalColumn: "CPR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSpecs_StaffLogin_StaffID",
                table: "GeneralSpecs",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarPrints_StaffLogin_StaffID",
                table: "RawEarPrints",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarPrints",
                column: "HATechnicalSpecID",
                principalTable: "TecnicalSpecs",
                principalColumn: "HATechinalSpecID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarScans_StaffLogin_StaffID",
                table: "RawEarScans",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarScans_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarScans",
                column: "HATechnicalSpecID",
                principalTable: "TecnicalSpecs",
                principalColumn: "HATechinalSpecID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_Patient_CPR",
                table: "TecnicalSpecs",
                column: "CPR",
                principalTable: "Patient",
                principalColumn: "CPR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_StaffLogin_StaffID",
                table: "TecnicalSpecs",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EarCast_Patient_PatientCPR",
                table: "EarCast");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSpecs_Patient_CPR",
                table: "GeneralSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSpecs_StaffLogin_StaffID",
                table: "GeneralSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarPrints_StaffLogin_StaffID",
                table: "RawEarPrints");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarPrints");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarScans_StaffLogin_StaffID",
                table: "RawEarScans");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarScans_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarScans");

            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_Patient_CPR",
                table: "TecnicalSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_StaffLogin_StaffID",
                table: "TecnicalSpecs");

            migrationBuilder.DropIndex(
                name: "IX_GeneralSpecs_CPR",
                table: "GeneralSpecs");

            migrationBuilder.DropColumn(
                name: "CPR",
                table: "GeneralSpecs");

            migrationBuilder.AddForeignKey(
                name: "FK_EarCast_Patient_PatientCPR",
                table: "EarCast",
                column: "PatientCPR",
                principalTable: "Patient",
                principalColumn: "CPR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSpecs_StaffLogin_StaffID",
                table: "GeneralSpecs",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarPrints_StaffLogin_StaffID",
                table: "RawEarPrints",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarPrints",
                column: "HATechnicalSpecID",
                principalTable: "TecnicalSpecs",
                principalColumn: "HATechinalSpecID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarScans_StaffLogin_StaffID",
                table: "RawEarScans",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarScans_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarScans",
                column: "HATechnicalSpecID",
                principalTable: "TecnicalSpecs",
                principalColumn: "HATechinalSpecID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_Patient_CPR",
                table: "TecnicalSpecs",
                column: "CPR",
                principalTable: "Patient",
                principalColumn: "CPR",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_StaffLogin_StaffID",
                table: "TecnicalSpecs",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
