using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Completed",
                table: "CustomerCourseRelation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Advisor",
                columns: table => new
                {
                    AdvisorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisor", x => x.AdvisorId);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "PracticeLesson",
                columns: table => new
                {
                    PracticeLessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeLesson", x => x.PracticeLessonId);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorCourseRelation",
                columns: table => new
                {
                    AdvisorCourseRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorCourseRelation", x => x.AdvisorCourseRelationId);
                    table.ForeignKey(
                        name: "FK_AdvisorCourseRelation_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId");
                    table.ForeignKey(
                        name: "FK_AdvisorCourseRelation_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                });

            migrationBuilder.CreateTable(
                name: "PackageAdvisorRelation",
                columns: table => new
                {
                    PackageAdvisorRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageAdvisorRelation", x => x.PackageAdvisorRelationId);
                    table.ForeignKey(
                        name: "FK_PackageAdvisorRelation_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId");
                    table.ForeignKey(
                        name: "FK_PackageAdvisorRelation_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "PackageId");
                });

            migrationBuilder.CreateTable(
                name: "PackageCourseRelation",
                columns: table => new
                {
                    PackageCourseRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageCourseRelation", x => x.PackageCourseRelationId);
                    table.ForeignKey(
                        name: "FK_PackageCourseRelation_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_PackageCourseRelation_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "PackageId");
                });

            migrationBuilder.CreateTable(
                name: "PackagePracticeLessonRelation",
                columns: table => new
                {
                    PackagePracticeLessonRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PracticeLessonId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagePracticeLessonRelation", x => x.PackagePracticeLessonRelationId);
                    table.ForeignKey(
                        name: "FK_PackagePracticeLessonRelation_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "PackageId");
                    table.ForeignKey(
                        name: "FK_PackagePracticeLessonRelation_PracticeLesson_PracticeLessonId",
                        column: x => x.PracticeLessonId,
                        principalTable: "PracticeLesson",
                        principalColumn: "PracticeLessonId");
                });

            migrationBuilder.CreateTable(
                name: "PracticeLessonCourseRelation",
                columns: table => new
                {
                    PracticeLessonCourseRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    PracticeLessonId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeLessonCourseRelation", x => x.PracticeLessonCourseRelationId);
                    table.ForeignKey(
                        name: "FK_PracticeLessonCourseRelation_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_PracticeLessonCourseRelation_PracticeLesson_PracticeLessonId",
                        column: x => x.PracticeLessonId,
                        principalTable: "PracticeLesson",
                        principalColumn: "PracticeLessonId");
                });

            migrationBuilder.CreateTable(
                name: "PracticeLessonGallery",
                columns: table => new
                {
                    PracticeLessonGalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PracticeLessonId = table.Column<int>(type: "int", nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeLessonGallery", x => x.PracticeLessonGalleryId);
                    table.ForeignKey(
                        name: "FK_PracticeLessonGallery_PracticeLesson_PracticeLessonId",
                        column: x => x.PracticeLessonId,
                        principalTable: "PracticeLesson",
                        principalColumn: "PracticeLessonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorCourseRelation_AdvisorId",
                table: "AdvisorCourseRelation",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorCourseRelation_CourseId",
                table: "AdvisorCourseRelation",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAdvisorRelation_AdvisorId",
                table: "PackageAdvisorRelation",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAdvisorRelation_PackageId",
                table: "PackageAdvisorRelation",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCourseRelation_CourseId",
                table: "PackageCourseRelation",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageCourseRelation_PackageId",
                table: "PackageCourseRelation",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagePracticeLessonRelation_PackageId",
                table: "PackagePracticeLessonRelation",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagePracticeLessonRelation_PracticeLessonId",
                table: "PackagePracticeLessonRelation",
                column: "PracticeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeLessonCourseRelation_CourseId",
                table: "PracticeLessonCourseRelation",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeLessonCourseRelation_PracticeLessonId",
                table: "PracticeLessonCourseRelation",
                column: "PracticeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeLessonGallery_PracticeLessonId",
                table: "PracticeLessonGallery",
                column: "PracticeLessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvisorCourseRelation");

            migrationBuilder.DropTable(
                name: "PackageAdvisorRelation");

            migrationBuilder.DropTable(
                name: "PackageCourseRelation");

            migrationBuilder.DropTable(
                name: "PackagePracticeLessonRelation");

            migrationBuilder.DropTable(
                name: "PracticeLessonCourseRelation");

            migrationBuilder.DropTable(
                name: "PracticeLessonGallery");

            migrationBuilder.DropTable(
                name: "Advisor");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "PracticeLesson");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "CustomerCourseRelation");
        }
    }
}
