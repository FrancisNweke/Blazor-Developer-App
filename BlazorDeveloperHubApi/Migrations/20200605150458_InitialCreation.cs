using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorDeveloperHubApi.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    DeveloperId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 80, nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    AnnualSalary = table.Column<decimal>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    ExperienceInYears = table.Column<double>(nullable: false),
                    DoesOpenSource = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_Country",
                        column: x => x.Country,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Country",
                table: "Cities",
                column: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
