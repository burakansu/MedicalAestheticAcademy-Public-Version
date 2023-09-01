using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeronaAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class _107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Departman_DepartmanId",
                table: "Personel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personel_PersonelTip_PersonelTipId",
                table: "Personel");

            migrationBuilder.DropTable(
                name: "Departman");

            migrationBuilder.DropTable(
                name: "KisitlamaControllerAction");

            migrationBuilder.DropTable(
                name: "PersonelArayuzKisitlama");

            migrationBuilder.DropTable(
                name: "PersonelKisitlamaRelation");

            migrationBuilder.DropTable(
                name: "PersonelTip");

            migrationBuilder.DropTable(
                name: "ArayuzKisitlama");

            migrationBuilder.DropTable(
                name: "Kisitlama");

            migrationBuilder.RenameColumn(
                name: "Unvan",
                table: "Personel",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Personel",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "PersonelTipId",
                table: "Personel",
                newName: "PersonelTypeId");

            migrationBuilder.RenameColumn(
                name: "Parola",
                table: "Personel",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Kod",
                table: "Personel",
                newName: "Head");

            migrationBuilder.RenameColumn(
                name: "Eposta",
                table: "Personel",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DepartmanId",
                table: "Personel",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "Adi",
                table: "Personel",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_Personel_PersonelTipId",
                table: "Personel",
                newName: "IX_Personel_PersonelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Personel_DepartmanId",
                table: "Personel",
                newName: "IX_Personel_DepartmentId");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "InterfaceRestriction",
                columns: table => new
                {
                    InterfaceRestrictionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterfaceRestriction", x => x.InterfaceRestrictionId);
                });

            migrationBuilder.CreateTable(
                name: "PersonelType",
                columns: table => new
                {
                    PersonelTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelType", x => x.PersonelTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Restriction",
                columns: table => new
                {
                    RestrictionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSpace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetDivId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restriction", x => x.RestrictionId);
                });

            migrationBuilder.CreateTable(
                name: "PersonelInterfaceRestriction",
                columns: table => new
                {
                    PersonelInterfaceRestrictionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    InterfaceRestrictionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelInterfaceRestriction", x => x.PersonelInterfaceRestrictionId);
                    table.ForeignKey(
                        name: "FK_PersonelInterfaceRestriction_InterfaceRestriction_InterfaceRestrictionId",
                        column: x => x.InterfaceRestrictionId,
                        principalTable: "InterfaceRestriction",
                        principalColumn: "InterfaceRestrictionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelInterfaceRestriction_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelInterfaceRestrictionRelation",
                columns: table => new
                {
                    PersonelInterfaceRestrictionRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    RestrictionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelInterfaceRestrictionRelation", x => x.PersonelInterfaceRestrictionRelationId);
                    table.ForeignKey(
                        name: "FK_PersonelInterfaceRestrictionRelation_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelInterfaceRestrictionRelation_Restriction_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "Restriction",
                        principalColumn: "RestrictionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestrictionControllerAction",
                columns: table => new
                {
                    RestrictionControllerActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestrictionId = table.Column<int>(type: "int", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestrictionControllerAction", x => x.RestrictionControllerActionId);
                    table.ForeignKey(
                        name: "FK_RestrictionControllerAction_Restriction_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "Restriction",
                        principalColumn: "RestrictionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelInterfaceRestriction_InterfaceRestrictionId",
                table: "PersonelInterfaceRestriction",
                column: "InterfaceRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelInterfaceRestriction_PersonelId",
                table: "PersonelInterfaceRestriction",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelInterfaceRestrictionRelation_PersonelId",
                table: "PersonelInterfaceRestrictionRelation",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelInterfaceRestrictionRelation_RestrictionId",
                table: "PersonelInterfaceRestrictionRelation",
                column: "RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_RestrictionControllerAction_RestrictionId",
                table: "RestrictionControllerAction",
                column: "RestrictionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Department_DepartmentId",
                table: "Personel",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_PersonelType_PersonelTypeId",
                table: "Personel",
                column: "PersonelTypeId",
                principalTable: "PersonelType",
                principalColumn: "PersonelTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personel_Department_DepartmentId",
                table: "Personel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personel_PersonelType_PersonelTypeId",
                table: "Personel");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "PersonelInterfaceRestriction");

            migrationBuilder.DropTable(
                name: "PersonelInterfaceRestrictionRelation");

            migrationBuilder.DropTable(
                name: "PersonelType");

            migrationBuilder.DropTable(
                name: "RestrictionControllerAction");

            migrationBuilder.DropTable(
                name: "InterfaceRestriction");

            migrationBuilder.DropTable(
                name: "Restriction");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Personel",
                newName: "Unvan");

            migrationBuilder.RenameColumn(
                name: "PersonelTypeId",
                table: "Personel",
                newName: "PersonelTipId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Personel",
                newName: "Telefon");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Personel",
                newName: "Parola");

            migrationBuilder.RenameColumn(
                name: "Head",
                table: "Personel",
                newName: "Kod");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Personel",
                newName: "Eposta");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Personel",
                newName: "DepartmanId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Personel",
                newName: "Adi");

            migrationBuilder.RenameIndex(
                name: "IX_Personel_PersonelTypeId",
                table: "Personel",
                newName: "IX_Personel_PersonelTipId");

            migrationBuilder.RenameIndex(
                name: "IX_Personel_DepartmentId",
                table: "Personel",
                newName: "IX_Personel_DepartmanId");

            migrationBuilder.CreateTable(
                name: "ArayuzKisitlama",
                columns: table => new
                {
                    ArayuzKisitlamaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArayuzKisitlama", x => x.ArayuzKisitlamaId);
                });

            migrationBuilder.CreateTable(
                name: "Departman",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departman", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "Kisitlama",
                columns: table => new
                {
                    KisitlamaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSpace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetDivId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisitlama", x => x.KisitlamaId);
                });

            migrationBuilder.CreateTable(
                name: "PersonelTip",
                columns: table => new
                {
                    PersonelTipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelTip", x => x.PersonelTipId);
                });

            migrationBuilder.CreateTable(
                name: "PersonelArayuzKisitlama",
                columns: table => new
                {
                    PersonelArayuzKisitlamaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArayuzKisitlamaId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelArayuzKisitlama", x => x.PersonelArayuzKisitlamaId);
                    table.ForeignKey(
                        name: "FK_PersonelArayuzKisitlama_ArayuzKisitlama_ArayuzKisitlamaId",
                        column: x => x.ArayuzKisitlamaId,
                        principalTable: "ArayuzKisitlama",
                        principalColumn: "ArayuzKisitlamaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelArayuzKisitlama_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KisitlamaControllerAction",
                columns: table => new
                {
                    KisitlamaControllerActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisitlamaId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisitlamaControllerAction", x => x.KisitlamaControllerActionId);
                    table.ForeignKey(
                        name: "FK_KisitlamaControllerAction_Kisitlama_KisitlamaId",
                        column: x => x.KisitlamaId,
                        principalTable: "Kisitlama",
                        principalColumn: "KisitlamaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelKisitlamaRelation",
                columns: table => new
                {
                    PersonelKisitlamaRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisitlamaId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelKisitlamaRelation", x => x.PersonelKisitlamaRelationId);
                    table.ForeignKey(
                        name: "FK_PersonelKisitlamaRelation_Kisitlama_KisitlamaId",
                        column: x => x.KisitlamaId,
                        principalTable: "Kisitlama",
                        principalColumn: "KisitlamaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelKisitlamaRelation_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KisitlamaControllerAction_KisitlamaId",
                table: "KisitlamaControllerAction",
                column: "KisitlamaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelArayuzKisitlama_ArayuzKisitlamaId",
                table: "PersonelArayuzKisitlama",
                column: "ArayuzKisitlamaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelArayuzKisitlama_PersonelId",
                table: "PersonelArayuzKisitlama",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelKisitlamaRelation_KisitlamaId",
                table: "PersonelKisitlamaRelation",
                column: "KisitlamaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelKisitlamaRelation_PersonelId",
                table: "PersonelKisitlamaRelation",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_Departman_DepartmanId",
                table: "Personel",
                column: "DepartmanId",
                principalTable: "Departman",
                principalColumn: "DepartmanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personel_PersonelTip_PersonelTipId",
                table: "Personel",
                column: "PersonelTipId",
                principalTable: "PersonelTip",
                principalColumn: "PersonelTipId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
