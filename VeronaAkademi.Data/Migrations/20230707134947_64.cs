using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _64 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Advisor_AdvisorId",
                table: "tybat");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Lesson_LessonId",
                table: "tybat");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Package_PackageId",
                table: "tybat");

            migrationBuilder.DropIndex(
                name: "IX_Order_AdvisorId",
                table: "tybat");

            migrationBuilder.DropIndex(
                name: "IX_Order_LessonId",
                table: "tybat");

            migrationBuilder.DropIndex(
                name: "IX_Order_PackageId",
                table: "tybat");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "tybat");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "tybat");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "tybat");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "tybat",
                newName: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "tybat",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "tybat",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductId",
                table: "tybat");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductId",
                table: "tybat");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "tybat",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "tybat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "tybat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "tybat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_AdvisorId",
                table: "tybat",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_LessonId",
                table: "tybat",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PackageId",
                table: "tybat",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Advisor_AdvisorId",
                table: "tybat",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Lesson_LessonId",
                table: "tybat",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Package_PackageId",
                table: "tybat",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
