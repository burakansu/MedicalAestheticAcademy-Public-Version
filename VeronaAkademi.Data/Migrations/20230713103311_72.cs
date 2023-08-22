using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _72 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturerMessage");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Message");

            migrationBuilder.CreateTable(
                name: "LecturerMessage",
                columns: table => new
                {
                    LecturerMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
    }
}
