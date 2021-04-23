using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class UpdateTechAndPatient : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_RawEarScans_HATechnicalSpecID",
                table: "RawEarScans");

            migrationBuilder.AddColumn<bool>(
                name: "Printed",
                table: "TecnicalSpecs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patient",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobilNummer",
                table: "Patient",
                type: "varchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarScans_HATechnicalSpecID",
                table: "RawEarScans",
                column: "HATechnicalSpecID",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_RawEarScans_HATechnicalSpecID",
                table: "RawEarScans");

            migrationBuilder.DropColumn(
                name: "Printed",
                table: "TecnicalSpecs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "MobilNummer",
                table: "Patient");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarScans_HATechnicalSpecID",
                table: "RawEarScans",
                column: "HATechnicalSpecID");

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
