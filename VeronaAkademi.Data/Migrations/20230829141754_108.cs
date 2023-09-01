using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _108 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anamnez_Form_FormId",
                table: "Anamnez");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicalExam_Form_FormId",
                table: "ClinicalExam");

            migrationBuilder.DropIndex(
                name: "IX_ClinicalExam_FormId",
                table: "ClinicalExam");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "ClinicalExam",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "Anamnez",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Anamnez_FormId",
                table: "Anamnez",
                newName: "IX_Anamnez_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "ClinicalExam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "Anamnez",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalExam_AdvisorId",
                table: "ClinicalExam",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalExam_CustomerId",
                table: "ClinicalExam",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Anamnez_AdvisorId",
                table: "Anamnez",
                column: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anamnez_Advisor_AdvisorId",
                table: "Anamnez",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anamnez_Customer_CustomerId",
                table: "Anamnez",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicalExam_Advisor_AdvisorId",
                table: "ClinicalExam",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "AdvisorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicalExam_Customer_CustomerId",
                table: "ClinicalExam",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anamnez_Advisor_AdvisorId",
                table: "Anamnez");

            migrationBuilder.DropForeignKey(
                name: "FK_Anamnez_Customer_CustomerId",
                table: "Anamnez");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicalExam_Advisor_AdvisorId",
                table: "ClinicalExam");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicalExam_Customer_CustomerId",
                table: "ClinicalExam");

            migrationBuilder.DropIndex(
                name: "IX_ClinicalExam_AdvisorId",
                table: "ClinicalExam");

            migrationBuilder.DropIndex(
                name: "IX_ClinicalExam_CustomerId",
                table: "ClinicalExam");

            migrationBuilder.DropIndex(
                name: "IX_Anamnez_AdvisorId",
                table: "Anamnez");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "ClinicalExam");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "Anamnez");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ClinicalExam",
                newName: "FormId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Anamnez",
                newName: "FormId");

            migrationBuilder.RenameIndex(
                name: "IX_Anamnez_CustomerId",
                table: "Anamnez",
                newName: "IX_Anamnez_FormId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalExam_FormId",
                table: "ClinicalExam",
                column: "FormId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Anamnez_Form_FormId",
                table: "Anamnez",
                column: "FormId",
                principalTable: "Form",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicalExam_Form_FormId",
                table: "ClinicalExam",
                column: "FormId",
                principalTable: "Form",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
