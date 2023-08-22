using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _50 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturerAdvisorRelation");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "PackageAdvisorRelation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "PackageAdvisorRelation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Advisor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "Advisor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Advisor_CurrencyId",
                table: "Advisor",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisor_LecturerId",
                table: "Advisor",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisor_Currency_CurrencyId",
                table: "Advisor",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisor_Lecturer_LecturerId",
                table: "Advisor",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advisor_Currency_CurrencyId",
                table: "Advisor");

            migrationBuilder.DropForeignKey(
                name: "FK_Advisor_Lecturer_LecturerId",
                table: "Advisor");

            migrationBuilder.DropIndex(
                name: "IX_Advisor_CurrencyId",
                table: "Advisor");

            migrationBuilder.DropIndex(
                name: "IX_Advisor_LecturerId",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "PackageAdvisorRelation");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "PackageAdvisorRelation");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Advisor");

            migrationBuilder.CreateTable(
                name: "LecturerAdvisorRelation",
                columns: table => new
                {
                    LecturerAdvisorRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerAdvisorRelation", x => x.LecturerAdvisorRelationId);
                    table.ForeignKey(
                        name: "FK_LecturerAdvisorRelation_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerAdvisorRelation_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAdvisorRelation_AdvisorId",
                table: "LecturerAdvisorRelation",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAdvisorRelation_LecturerId",
                table: "LecturerAdvisorRelation",
                column: "LecturerId");
        }
    }
}
