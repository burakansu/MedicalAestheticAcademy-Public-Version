using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Package_CurrencyId",
                table: "Package",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Currency_CurrencyId",
                table: "Package",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Currency_CurrencyId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_CurrencyId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Package");
        }
    }
}
