using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    PanaromicXRay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeftProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpperOkluzal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BottomOkluzal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İnnerNoiseSmilePhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontProfileRelax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontProfileSmile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontProfileMounth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileRelax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileSmile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileMounth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpperAndLowerPlasterModel_WaxClosure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandAnkleFilm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.FormId);
                    table.ForeignKey(
                        name: "FK_Form_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Form_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anamnez",
                columns: table => new
                {
                    AnamnezId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnez", x => x.AnamnezId);
                    table.ForeignKey(
                        name: "FK_Anamnez_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalExam",
                columns: table => new
                {
                    ClinicalExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalExam", x => x.ClinicalExamId);
                    table.ForeignKey(
                        name: "FK_ClinicalExam_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anamnez_FormId",
                table: "Anamnez",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalExam_FormId",
                table: "ClinicalExam",
                column: "FormId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Form_AdvisorId",
                table: "Form",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_CustomerId",
                table: "Form",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anamnez");

            migrationBuilder.DropTable(
                name: "ClinicalExam");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
