using Microsoft.EntityFrameworkCore.Migrations;

namespace E18I4DABH4Gr4.Migrations
{
    public partial class Initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmartGrids",
                columns: table => new
                {
                    SmartGridId = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartGrids", x => x.SmartGridId);
                });

            migrationBuilder.CreateTable(
                name: "Prosumers",
                columns: table => new
                {
                    ProsumerId = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    prosumerType = table.Column<int>(nullable: false),
                    KWhAmount = table.Column<int>(nullable: false),
                    ConsumerFK = table.Column<string>(nullable: true),
                    ProducerFK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prosumers", x => x.ProsumerId);
                    table.ForeignKey(
                        name: "FK_Prosumers_SmartGrids_ConsumerFK",
                        column: x => x.ConsumerFK,
                        principalTable: "SmartGrids",
                        principalColumn: "SmartGridId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prosumers_SmartGrids_ProducerFK",
                        column: x => x.ProducerFK,
                        principalTable: "SmartGrids",
                        principalColumn: "SmartGridId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prosumers_ConsumerFK",
                table: "Prosumers",
                column: "ConsumerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Prosumers_ProducerFK",
                table: "Prosumers",
                column: "ProducerFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prosumers");

            migrationBuilder.DropTable(
                name: "SmartGrids");
        }
    }
}
