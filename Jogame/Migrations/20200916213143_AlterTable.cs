using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogame.Migrations
{
    public partial class AlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Jogos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Jogadors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Jogadors");
        }
    }
}
