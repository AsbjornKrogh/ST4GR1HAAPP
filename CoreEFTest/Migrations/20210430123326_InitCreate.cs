using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class InitCreate : Migration
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
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MobilNummer = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
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
                    StaffStatus = table.Column<int>(type: "int", nullable: false)
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
                    EarSide = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSpecs",
                columns: table => new
                {
                    HAGeneralSpecID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    EarSide = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    PatientCPR = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSpecs", x => x.HAGeneralSpecID);
                    table.ForeignKey(
                        name: "FK_GeneralSpecs_Patient_PatientCPR",
                        column: x => x.PatientCPR,
                        principalTable: "Patient",
                        principalColumn: "CPR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TecnicalSpecs",
                columns: table => new
                {
                    HATechinalSpecID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarSide = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Printed = table.Column<bool>(type: "bit", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    CPR = table.Column<string>(type: "varchar(11)", nullable: false),
                    HAGenerelSpecID = table.Column<int>(type: "int", nullable: false),
                    ScanID = table.Column<int>(type: "int", nullable: false),
                    PatientCPR = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicalSpecs", x => x.HATechinalSpecID);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_GeneralSpecs_HAGenerelSpecID",
                        column: x => x.HAGenerelSpecID,
                        principalTable: "GeneralSpecs",
                        principalColumn: "HAGeneralSpecID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_Patient_CPR",
                        column: x => x.CPR,
                        principalTable: "Patient",
                        principalColumn: "CPR",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_Patient_PatientCPR",
                        column: x => x.PatientCPR,
                        principalTable: "Patient",
                        principalColumn: "CPR",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_StaffLogin_StaffID",
                        column: x => x.StaffID,
                        principalTable: "StaffLogin",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RawEarPrints",
                columns: table => new
                {
                    EarPrintID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarSide = table.Column<int>(type: "int", nullable: false),
                    PrintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    HATechnicalSpecID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawEarPrints", x => x.EarPrintID);
                    table.ForeignKey(
                        name: "FK_RawEarPrints_StaffLogin_StaffID",
                        column: x => x.StaffID,
                        principalTable: "StaffLogin",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RawEarPrints_TecnicalSpecs_HATechnicalSpecID",
                        column: x => x.HATechnicalSpecID,
                        principalTable: "TecnicalSpecs",
                        principalColumn: "HATechinalSpecID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RawEarScans",
                columns: table => new
                {
                    ScanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scan = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EarSide = table.Column<int>(type: "int", nullable: false),
                    ScanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    HATechnicalSpecID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawEarScans", x => x.ScanID);
                    table.ForeignKey(
                        name: "FK_RawEarScans_StaffLogin_StaffID",
                        column: x => x.StaffID,
                        principalTable: "StaffLogin",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RawEarScans_TecnicalSpecs_HATechnicalSpecID",
                        column: x => x.HATechnicalSpecID,
                        principalTable: "TecnicalSpecs",
                        principalColumn: "HATechinalSpecID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EarCast_PatientCPR",
                table: "EarCast",
                column: "PatientCPR");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSpecs_PatientCPR",
                table: "GeneralSpecs",
                column: "PatientCPR");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarPrints_HATechnicalSpecID",
                table: "RawEarPrints",
                column: "HATechnicalSpecID");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarPrints_StaffID",
                table: "RawEarPrints",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarScans_HATechnicalSpecID",
                table: "RawEarScans",
                column: "HATechnicalSpecID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawEarScans_StaffID",
                table: "RawEarScans",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_CPR",
                table: "TecnicalSpecs",
                column: "CPR");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_HAGenerelSpecID",
                table: "TecnicalSpecs",
                column: "HAGenerelSpecID");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_PatientCPR",
                table: "TecnicalSpecs",
                column: "PatientCPR");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_StaffID",
                table: "TecnicalSpecs",
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
                name: "TecnicalSpecs");

            migrationBuilder.DropTable(
                name: "GeneralSpecs");

            migrationBuilder.DropTable(
                name: "StaffLogin");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
