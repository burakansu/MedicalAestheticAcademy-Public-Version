using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _99 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebSiteData",
                columns: table => new
                {
                    WebsiteDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderSecondary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextReccommendedCourses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextStudentFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextReccommendedSkill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSiteData", x => x.WebsiteDataId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebSiteData");
        }
    }
}
