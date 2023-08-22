using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _61 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Advisor_AdvisorId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Lesson_LessonId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Package_PackageId",
                table: "Basket");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Basket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "Basket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdvisorId",
                table: "Basket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Advisor_AdvisorId",
                table: "Basket",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Lesson_LessonId",
                table: "Basket",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Package_PackageId",
                table: "Basket",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Advisor_AdvisorId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Lesson_LessonId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Package_PackageId",
                table: "Basket");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdvisorId",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Advisor_AdvisorId",
                table: "Basket",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Lesson_LessonId",
                table: "Basket",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Package_PackageId",
                table: "Basket",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
