using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Advisor");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PracticeLesson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Advisor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Advisor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LecturerAdvisorRelation",
                columns: table => new
                {
                    LecturerAdvisorRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturerAdvisorRelation");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "PracticeLesson");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Advisor");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Advisor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Advisor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
