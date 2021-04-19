using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class ContextAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSpec_StaffLogin_StaffID",
                table: "GeneralSpec");

            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpec_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralSpec",
                table: "GeneralSpec");

            migrationBuilder.RenameTable(
                name: "GeneralSpec",
                newName: "GeneralSpecs");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralSpec_StaffID",
                table: "GeneralSpecs",
                newName: "IX_GeneralSpecs_StaffID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralSpecs",
                table: "GeneralSpecs",
                column: "HAGeneralSpecID");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSpecs_StaffLogin_StaffID",
                table: "GeneralSpecs",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpecs_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs",
                column: "GeneralSpecHAGeneralSpecID",
                principalTable: "GeneralSpecs",
                principalColumn: "HAGeneralSpecID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSpecs_StaffLogin_StaffID",
                table: "GeneralSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpecs_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralSpecs",
                table: "GeneralSpecs");

            migrationBuilder.RenameTable(
                name: "GeneralSpecs",
                newName: "GeneralSpec");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralSpecs_StaffID",
                table: "GeneralSpec",
                newName: "IX_GeneralSpec_StaffID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralSpec",
                table: "GeneralSpec",
                column: "HAGeneralSpecID");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSpec_StaffLogin_StaffID",
                table: "GeneralSpec",
                column: "StaffID",
                principalTable: "StaffLogin",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpec_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs",
                column: "GeneralSpecHAGeneralSpecID",
                principalTable: "GeneralSpec",
                principalColumn: "HAGeneralSpecID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
