using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E18I4DABH4Gr4.Migrations
{
    public partial class AddSmartggriddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmartGrids",
                columns: table => new
                {
                    SmartGridId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartGrids", x => x.SmartGridId);
                });

            migrationBuilder.CreateTable(
                name: "Prosumer",
                columns: table => new
                {
                    ProsumerId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    prosumerType = table.Column<int>(nullable: false),
                    KWhAmount = table.Column<int>(nullable: false),
                    SmartGridId = table.Column<int>(nullable: true),
                    SmartGridId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prosumer", x => x.ProsumerId);
                    table.ForeignKey(
                        name: "FK_Prosumer_SmartGrids_SmartGridId",
                        column: x => x.SmartGridId,
                        principalTable: "SmartGrids",
                        principalColumn: "SmartGridId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prosumer_SmartGrids_SmartGridId1",
                        column: x => x.SmartGridId1,
                        principalTable: "SmartGrids",
                        principalColumn: "SmartGridId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prosumer_SmartGridId",
                table: "Prosumer",
                column: "SmartGridId");

            migrationBuilder.CreateIndex(
                name: "IX_Prosumer_SmartGridId1",
                table: "Prosumer",
                column: "SmartGridId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prosumer");

            migrationBuilder.DropTable(
                name: "SmartGrids");
        }
    }
}
