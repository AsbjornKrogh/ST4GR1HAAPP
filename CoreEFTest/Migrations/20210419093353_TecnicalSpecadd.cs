using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class TecnicalSpecadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TecnicalSpecs",
                columns: table => new
                {
                    HATechinalSpecID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ear = table.Column<string>(type: "char(1)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    CPR = table.Column<int>(type: "int", nullable: false),
                    patientCPR = table.Column<string>(type: "varchar(11)", nullable: true),
                    ScanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicalSpecs", x => x.HATechinalSpecID);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_Patient_patientCPR",
                        column: x => x.patientCPR,
                        principalTable: "Patient",
                        principalColumn: "CPR",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_RawEarScans_ScanID",
                        column: x => x.ScanID,
                        principalTable: "RawEarScans",
                        principalColumn: "ScanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_StaffLogin_StaffID",
                        column: x => x.StaffID,
                        principalTable: "StaffLogin",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RawEarPrints_TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints",
                column: "TecnicalSpecHATechinalSpecID");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_patientCPR",
                table: "TecnicalSpecs",
                column: "patientCPR");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_ScanID",
                table: "TecnicalSpecs",
                column: "ScanID");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_StaffID",
                table: "TecnicalSpecs",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints",
                column: "TecnicalSpecHATechinalSpecID",
                principalTable: "TecnicalSpecs",
                principalColumn: "HATechinalSpecID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints");

            migrationBuilder.DropTable(
                name: "TecnicalSpecs");

            migrationBuilder.DropIndex(
                name: "IX_RawEarPrints_TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints");

            migrationBuilder.DropColumn(
                name: "TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints");
        }
    }
}
