using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class InitialCreat : Migration
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSpec",
                columns: table => new
                {
                    HAGeneralSpecID = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    EarSide = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSpec", x => x.HAGeneralSpecID);
                    table.ForeignKey(
                        name: "FK_GeneralSpec_StaffLogin_StaffID",
                        column: x => x.StaffID,
                        principalTable: "StaffLogin",
                        principalColumn: "StaffID",
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
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    CPR = table.Column<int>(type: "int", nullable: false),
                    patientCPR = table.Column<string>(type: "varchar(11)", nullable: true),
                    HAinfo = table.Column<int>(type: "int", nullable: false),
                    GeneralSpecHAGeneralSpecID = table.Column<int>(type: "int", nullable: true),
                    ScanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicalSpecs", x => x.HATechinalSpecID);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_GeneralSpec_GeneralSpecHAGeneralSpecID",
                        column: x => x.GeneralSpecHAGeneralSpecID,
                        principalTable: "GeneralSpec",
                        principalColumn: "HAGeneralSpecID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TecnicalSpecs_Patient_patientCPR",
                        column: x => x.patientCPR,
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
                name: "IX_GeneralSpec_StaffID",
                table: "GeneralSpec",
                column: "StaffID");

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
                column: "HATechnicalSpecID");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarScans_StaffID",
                table: "RawEarScans",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs",
                column: "GeneralSpecHAGeneralSpecID");

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
                name: "FK_TecnicalSpecs_RawEarScans_ScanID",
                table: "TecnicalSpecs",
                column: "ScanID",
                principalTable: "RawEarScans",
                principalColumn: "ScanID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_Patient_patientCPR",
                table: "TecnicalSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSpec_StaffLogin_StaffID",
                table: "GeneralSpec");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarScans_StaffLogin_StaffID",
                table: "RawEarScans");

            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_StaffLogin_StaffID",
                table: "TecnicalSpecs");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarScans_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarScans");

            migrationBuilder.DropTable(
                name: "EarCast");

            migrationBuilder.DropTable(
                name: "RawEarPrints");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "StaffLogin");

            migrationBuilder.DropTable(
                name: "TecnicalSpecs");

            migrationBuilder.DropTable(
                name: "GeneralSpec");

            migrationBuilder.DropTable(
                name: "RawEarScans");
        }
    }
}
