using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _67 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAdvisorRelation",
                columns: table => new
                {
                    CustomerAdvisorRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdvisorRelation", x => x.CustomerAdvisorRelationId);
                    table.ForeignKey(
                        name: "FK_CustomerAdvisorRelation_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAdvisorRelation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPracticeLessonRelation",
                columns: table => new
                {
                    CustomerPracticeLessonRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeLessonId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPracticeLessonRelation", x => x.CustomerPracticeLessonRelationId);
                    table.ForeignKey(
                        name: "FK_CustomerPracticeLessonRelation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPracticeLessonRelation_PracticeLesson_PracticeLessonId",
                        column: x => x.PracticeLessonId,
                        principalTable: "PracticeLesson",
                        principalColumn: "PracticeLessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdvisorRelation_AdvisorId",
                table: "CustomerAdvisorRelation",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdvisorRelation_CustomerId",
                table: "CustomerAdvisorRelation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPracticeLessonRelation_CustomerId",
                table: "CustomerPracticeLessonRelation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPracticeLessonRelation_PracticeLessonId",
                table: "CustomerPracticeLessonRelation",
                column: "PracticeLessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAdvisorRelation");

            migrationBuilder.DropTable(
                name: "CustomerPracticeLessonRelation");
        }
    }
}
