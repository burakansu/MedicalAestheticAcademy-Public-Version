using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "PackageAdvisorRelation");

            migrationBuilder.DropColumn(
                name: "EklemeTarihi",
                table: "PackageAdvisorRelation");

            migrationBuilder.DropColumn(
                name: "GuncellemeTarihi",
                table: "PackageAdvisorRelation");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "PackageAdvisorRelation");

            migrationBuilder.DropColumn(
                name: "Sira",
                table: "PackageAdvisorRelation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "PackageAdvisorRelation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeTarihi",
                table: "PackageAdvisorRelation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeTarihi",
                table: "PackageAdvisorRelation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "PackageAdvisorRelation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Sira",
                table: "PackageAdvisorRelation",
                type: "int",
                nullable: true);
        }
    }
}
