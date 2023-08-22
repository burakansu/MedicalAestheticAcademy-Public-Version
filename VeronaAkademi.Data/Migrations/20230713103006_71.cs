using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _71 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LecturerMessage",
                columns: table => new
                {
                    LecturerMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_LecturerMessage", x => x.LecturerMessageId);
                    table.ForeignKey(
                        name: "FK_LecturerMessage_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerMessage_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LecturerMessage_AdvisorId",
                table: "LecturerMessage",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerMessage_LecturerId",
                table: "LecturerMessage",
                column: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturerMessage");
        }
    }
}
