using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suertes",
                columns: table => new
                {
                    futuro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    vision = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suertes", x => x.futuro);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suertes");
        }
    }
}
