using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "WebSiteData",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "WebSiteData",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "WebSiteData",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "WebSiteData",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "WebSiteData",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Trailer",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Trailer",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Trailer",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Trailer",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Trailer",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "SkillGroup",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "SkillGroup",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "SkillGroup",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "SkillGroup",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "SkillGroup",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "SkillCourseRelation",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "SkillCourseRelation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "SkillCourseRelation",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "SkillCourseRelation",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "SkillCourseRelation",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Skill",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Skill",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Skill",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Skill",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Skill",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Review",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Review",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Review",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Review",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Review",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "ProfessionCourseRelation",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "ProfessionCourseRelation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "ProfessionCourseRelation",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "ProfessionCourseRelation",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "ProfessionCourseRelation",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Profession",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Profession",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Profession",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Profession",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Profession",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "PracticeLessonGallery",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "PracticeLessonGallery",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "PracticeLessonGallery",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "PracticeLessonGallery",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "PracticeLessonGallery",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "PracticeLessonCourseRelation",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "PracticeLessonCourseRelation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "PracticeLessonCourseRelation",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "PracticeLessonCourseRelation",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "PracticeLessonCourseRelation",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "PracticeLesson",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "PracticeLesson",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "PracticeLesson",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "PracticeLesson",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "PracticeLesson",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Personel",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Personel",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Personel",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Personel",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Personel",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "PackagePracticeLessonRelation",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "PackagePracticeLessonRelation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "PackagePracticeLessonRelation",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "PackagePracticeLessonRelation",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "PackagePracticeLessonRelation",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "PackageCourseRelation",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "PackageCourseRelation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "PackageCourseRelation",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "PackageCourseRelation",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "PackageCourseRelation",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "PackageAdvisorRelation",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "PackageAdvisorRelation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "PackageAdvisorRelation",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "PackageAdvisorRelation",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "PackageAdvisorRelation",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Package",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Package",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Package",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Package",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Package",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Order",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Order",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Order",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Order",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Order",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Message",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Message",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Message",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Message",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Message",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Lesson",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Lesson",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Lesson",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Lesson",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Lesson",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "LecturerCourseRelation",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "LecturerCourseRelation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "LecturerCourseRelation",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "LecturerCourseRelation",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "LecturerCourseRelation",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Lecturer",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Lecturer",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Lecturer",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Lecturer",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Lecturer",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Form",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Form",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Form",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Form",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Form",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Customer",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Customer",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Customer",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Customer",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Customer",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Course",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Course",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Course",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Course",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Course",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "ClinicalExam",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "ClinicalExam",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "ClinicalExam",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "ClinicalExam",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "ClinicalExam",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "CategoryGroup",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "CategoryGroup",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "CategoryGroup",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "CategoryGroup",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "CategoryGroup",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Category",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Category",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Category",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Category",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Category",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Anamnez",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Anamnez",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Anamnez",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Anamnez",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Anamnez",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "AdvisorCourseRelation",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "AdvisorCourseRelation",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "AdvisorCourseRelation",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "AdvisorCourseRelation",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "AdvisorCourseRelation",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sira",
                table: "Advisor",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Silindi",
                table: "Advisor",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Advisor",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EklemeTarihi",
                table: "Advisor",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "Advisor",
                newName: "Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "WebSiteData",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "WebSiteData",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "WebSiteData",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "WebSiteData",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "WebSiteData",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Trailer",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Trailer",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Trailer",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Trailer",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Trailer",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "SkillGroup",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "SkillGroup",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "SkillGroup",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "SkillGroup",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "SkillGroup",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "SkillCourseRelation",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "SkillCourseRelation",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "SkillCourseRelation",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "SkillCourseRelation",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "SkillCourseRelation",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Skill",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Skill",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Skill",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Skill",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Skill",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Review",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Review",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Review",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Review",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Review",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ProfessionCourseRelation",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "ProfessionCourseRelation",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "ProfessionCourseRelation",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ProfessionCourseRelation",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ProfessionCourseRelation",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Profession",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Profession",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Profession",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Profession",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Profession",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "PracticeLessonGallery",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "PracticeLessonGallery",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "PracticeLessonGallery",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "PracticeLessonGallery",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "PracticeLessonGallery",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "PracticeLessonCourseRelation",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "PracticeLessonCourseRelation",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "PracticeLessonCourseRelation",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "PracticeLessonCourseRelation",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "PracticeLessonCourseRelation",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "PracticeLesson",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "PracticeLesson",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "PracticeLesson",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "PracticeLesson",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "PracticeLesson",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Personel",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Personel",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Personel",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Personel",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Personel",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "PackagePracticeLessonRelation",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "PackagePracticeLessonRelation",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "PackagePracticeLessonRelation",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "PackagePracticeLessonRelation",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "PackagePracticeLessonRelation",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "PackageCourseRelation",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "PackageCourseRelation",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "PackageCourseRelation",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "PackageCourseRelation",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "PackageCourseRelation",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "PackageAdvisorRelation",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "PackageAdvisorRelation",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "PackageAdvisorRelation",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "PackageAdvisorRelation",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "PackageAdvisorRelation",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Package",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Package",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Package",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Package",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Package",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Order",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Order",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Order",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Order",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Order",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Message",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Message",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Message",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Message",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Message",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Lesson",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Lesson",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Lesson",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Lesson",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Lesson",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "LecturerCourseRelation",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "LecturerCourseRelation",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "LecturerCourseRelation",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "LecturerCourseRelation",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "LecturerCourseRelation",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Lecturer",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Lecturer",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Lecturer",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Lecturer",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Lecturer",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Form",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Form",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Form",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Form",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Form",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Customer",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Customer",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Customer",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Customer",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Customer",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Course",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Course",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Course",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Course",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Course",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ClinicalExam",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "ClinicalExam",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "ClinicalExam",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ClinicalExam",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ClinicalExam",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "CategoryGroup",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "CategoryGroup",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "CategoryGroup",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "CategoryGroup",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "CategoryGroup",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Category",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Category",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Category",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Category",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Category",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Anamnez",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Anamnez",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Anamnez",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Anamnez",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Anamnez",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "AdvisorCourseRelation",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "AdvisorCourseRelation",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "AdvisorCourseRelation",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "AdvisorCourseRelation",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "AdvisorCourseRelation",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Advisor",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Advisor",
                newName: "Sira");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Advisor",
                newName: "Silindi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Advisor",
                newName: "EklemeTarihi");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Advisor",
                newName: "Aktif");
        }
    }
}
