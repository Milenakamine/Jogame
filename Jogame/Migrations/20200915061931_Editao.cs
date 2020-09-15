using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogame.Migrations
{
    public partial class Editao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Jogadors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Jogadors");
        }
    }
}
