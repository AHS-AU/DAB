using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E18I4DABH32D1Gr4.Migrations
{
    public partial class nani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    cityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cityName = table.Column<string>(nullable: true),
                    zipCode = table.Column<int>(nullable: false),
                    countryRegion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    PrimaryAddressaddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    addressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    streetAddress = table.Column<string>(nullable: true),
                    cityAtAddresscityId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.addressId);
                    table.ForeignKey(
                        name: "FK_address_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_address_city_cityAtAddresscityId",
                        column: x => x.cityAtAddresscityId,
                        principalTable: "city",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emailAddress",
                columns: table => new
                {
                    emailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailAddress", x => x.emailId);
                    table.ForeignKey(
                        name: "FK_emailAddress_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_PersonId",
                table: "address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_address_cityAtAddresscityId",
                table: "address",
                column: "cityAtAddresscityId");

            migrationBuilder.CreateIndex(
                name: "IX_emailAddress_PersonId",
                table: "emailAddress",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_people_PrimaryAddressaddressId",
                table: "people",
                column: "PrimaryAddressaddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_people_address_PrimaryAddressaddressId",
                table: "people",
                column: "PrimaryAddressaddressId",
                principalTable: "address",
                principalColumn: "addressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_people_PersonId",
                table: "address");

            migrationBuilder.DropTable(
                name: "emailAddress");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
