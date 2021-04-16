using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    CPR = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Lastname = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Adress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    zipcode = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.CPR);
                });

            migrationBuilder.CreateTable(
                name: "StaffLogin",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    StaffStatus = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLogin", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "EarCast",
                columns: table => new
                {
                    EarCastID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ear = table.Column<string>(type: "char(1)", nullable: false),
                    CastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientCPR = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarCast", x => x.EarCastID);
                    table.ForeignKey(
                        name: "FK_EarCast_Patient_PatientCPR",
                        column: x => x.PatientCPR,
                        principalTable: "Patient",
                        principalColumn: "CPR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawEarPrints",
                columns: table => new
                {
                    EarPrintID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawEarPrints", x => x.EarPrintID);
                    table.ForeignKey(
                        name: "FK_RawEarPrints_StaffLogin_StaffID",
                        column: x => x.StaffID,
                        principalTable: "StaffLogin",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawEarScans",
                columns: table => new
                {
                    ScanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawEarScans", x => x.ScanID);
                    table.ForeignKey(
                        name: "FK_RawEarScans_StaffLogin_StaffID",
                        column: x => x.StaffID,
                        principalTable: "StaffLogin",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EarCast_PatientCPR",
                table: "EarCast",
                column: "PatientCPR");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarPrints_StaffID",
                table: "RawEarPrints",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarScans_StaffID",
                table: "RawEarScans",
                column: "StaffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarCast");

            migrationBuilder.DropTable(
                name: "RawEarPrints");

            migrationBuilder.DropTable(
                name: "RawEarScans");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "StaffLogin");
        }
    }
}
