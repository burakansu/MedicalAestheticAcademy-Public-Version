using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _62 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Advisor_AdvisorId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Package_PackageId",
                table: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Basket_AdvisorId",
                table: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Basket_PackageId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Basket");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Basket",
                newName: "ProductId");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ProductId",
                table: "Basket",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Product_ProductId",
                table: "Basket",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Product_ProductId",
                table: "Basket");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Basket_ProductId",
                table: "Basket");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Basket",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "Basket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Basket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Basket_AdvisorId",
                table: "Basket",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_PackageId",
                table: "Basket",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Advisor_AdvisorId",
                table: "Basket",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Package_PackageId",
                table: "Basket",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "PackageId");
        }
    }
}
