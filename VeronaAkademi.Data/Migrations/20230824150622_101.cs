using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "WebSiteData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeTarihi",
                table: "WebSiteData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeTarihi",
                table: "WebSiteData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "WebSiteData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Sira",
                table: "WebSiteData",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "WebSiteData");

            migrationBuilder.DropColumn(
                name: "EklemeTarihi",
                table: "WebSiteData");

            migrationBuilder.DropColumn(
                name: "GuncellemeTarihi",
                table: "WebSiteData");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "WebSiteData");

            migrationBuilder.DropColumn(
                name: "Sira",
                table: "WebSiteData");
        }
    }
}
