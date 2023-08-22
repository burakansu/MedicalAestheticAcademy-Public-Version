using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _56 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "tybat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "tybat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_PackageId",
                table: "tybat",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_PackageId",
                table: "Basket",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Package_PackageId",
                table: "Basket",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Package_PackageId",
                table: "tybat",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Package_PackageId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Package_PackageId",
                table: "tybat");

            migrationBuilder.DropIndex(
                name: "IX_Order_PackageId",
                table: "tybat");

            migrationBuilder.DropIndex(
                name: "IX_Basket_PackageId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "tybat");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "tybat");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Basket");
        }
    }
}
