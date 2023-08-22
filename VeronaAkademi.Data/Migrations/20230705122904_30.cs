using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Customer",
                type: "int",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CurrencyId",
                table: "Customer",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Currency_CurrencyId",
                table: "Customer",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Currency_CurrencyId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CurrencyId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Customer");
        }
    }
}
