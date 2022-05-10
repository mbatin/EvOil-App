using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvOil.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inflamed = table.Column<float>(type: "real", nullable: false),
                    Moldy = table.Column<float>(type: "real", nullable: false),
                    Sour = table.Column<float>(type: "real", nullable: false),
                    Frosted = table.Column<float>(type: "real", nullable: false),
                    Burned = table.Column<float>(type: "real", nullable: false),
                    Fruity = table.Column<float>(type: "real", nullable: false),
                    Spicy = table.Column<float>(type: "real", nullable: false),
                    Bitter = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oils",
                columns: table => new
                {
                    CodeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oils", x => x.CodeName);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_Id",
                table: "Evaluations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oils_CodeName",
                table: "Oils",
                column: "CodeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oils_FullName",
                table: "Oils",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_Id",
                table: "Organizers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Password",
                table: "Users",
                column: "Password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Oils");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
