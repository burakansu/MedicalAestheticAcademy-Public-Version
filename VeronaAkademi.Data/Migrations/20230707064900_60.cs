using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _60 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "tybat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_AdvisorId",
                table: "tybat",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_AdvisorId",
                table: "Basket",
                column: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Advisor_AdvisorId",
                table: "Basket",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Advisor_AdvisorId",
                table: "tybat",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Advisor_AdvisorId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Advisor_AdvisorId",
                table: "tybat");

            migrationBuilder.DropIndex(
                name: "IX_Order_AdvisorId",
                table: "tybat");

            migrationBuilder.DropIndex(
                name: "IX_Basket_AdvisorId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "tybat");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "Basket");
        }
    }
}
