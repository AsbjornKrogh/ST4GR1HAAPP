using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreEFTest.Migrations
{
    public partial class GeneralSpecAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints");

            migrationBuilder.DropIndex(
                name: "IX_RawEarPrints_TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints");

            migrationBuilder.DropColumn(
                name: "Ear",
                table: "TecnicalSpecs");

            migrationBuilder.DropColumn(
                name: "TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints");

            migrationBuilder.AddColumn<int>(
                name: "EarSide",
                table: "TecnicalSpecs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HAinfo",
                table: "TecnicalSpecs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StaffStatus",
                table: "StaffLogin",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AddColumn<int>(
                name: "HATechnicalSpecID",
                table: "RawEarScans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Scan",
                table: "RawEarScans",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "HATechnicalSpecID",
                table: "RawEarPrints",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TecnicalSpecs_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs",
                column: "GeneralSpecHAGeneralSpecID");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarScans_HATechnicalSpecID",
                table: "RawEarScans",
                column: "HATechnicalSpecID");

            migrationBuilder.CreateIndex(
                name: "IX_RawEarPrints_HATechnicalSpecID",
                table: "RawEarPrints",
                column: "HATechnicalSpecID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSpec_StaffID",
                table: "GeneralSpec",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarPrints",
                column: "HATechnicalSpecID",
                principalTable: "TecnicalSpecs",
                principalColumn: "HATechinalSpecID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarScans_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarScans",
                column: "HATechnicalSpecID",
                principalTable: "TecnicalSpecs",
                principalColumn: "HATechinalSpecID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpec_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs",
                column: "GeneralSpecHAGeneralSpecID",
                principalTable: "GeneralSpec",
                principalColumn: "HAGeneralSpecID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarPrints");

            migrationBuilder.DropForeignKey(
                name: "FK_RawEarScans_TecnicalSpecs_HATechnicalSpecID",
                table: "RawEarScans");

            migrationBuilder.DropForeignKey(
                name: "FK_TecnicalSpecs_GeneralSpec_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs");

            migrationBuilder.DropTable(
                name: "GeneralSpec");

            migrationBuilder.DropIndex(
                name: "IX_TecnicalSpecs_GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs");

            migrationBuilder.DropIndex(
                name: "IX_RawEarScans_HATechnicalSpecID",
                table: "RawEarScans");

            migrationBuilder.DropIndex(
                name: "IX_RawEarPrints_HATechnicalSpecID",
                table: "RawEarPrints");

            migrationBuilder.DropColumn(
                name: "EarSide",
                table: "TecnicalSpecs");

            migrationBuilder.DropColumn(
                name: "GeneralSpecHAGeneralSpecID",
                table: "TecnicalSpecs");

            migrationBuilder.DropColumn(
                name: "HAinfo",
                table: "TecnicalSpecs");

            migrationBuilder.DropColumn(
                name: "HATechnicalSpecID",
                table: "RawEarScans");

            migrationBuilder.DropColumn(
                name: "Scan",
                table: "RawEarScans");

            migrationBuilder.DropColumn(
                name: "HATechnicalSpecID",
                table: "RawEarPrints");

            migrationBuilder.AddColumn<string>(
                name: "Ear",
                table: "TecnicalSpecs",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "StaffStatus",
                table: "StaffLogin",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawEarPrints_TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints",
                column: "TecnicalSpecHATechinalSpecID");

            migrationBuilder.AddForeignKey(
                name: "FK_RawEarPrints_TecnicalSpecs_TecnicalSpecHATechinalSpecID",
                table: "RawEarPrints",
                column: "TecnicalSpecHATechinalSpecID",
                principalTable: "TecnicalSpecs",
                principalColumn: "HATechinalSpecID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
