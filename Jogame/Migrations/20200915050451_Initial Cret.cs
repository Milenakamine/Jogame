﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogame.Migrations
{
    public partial class InitialCret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogadors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JogosJogadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdJogador = table.Column<Guid>(nullable: false),
                    IdJogo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogosJogadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogosJogadores_Jogadors_IdJogador",
                        column: x => x.IdJogador,
                        principalTable: "Jogadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogosJogadores_Jogos_IdJogo",
                        column: x => x.IdJogo,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogosJogadores_IdJogador",
                table: "JogosJogadores",
                column: "IdJogador");

            migrationBuilder.CreateIndex(
                name: "IX_JogosJogadores_IdJogo",
                table: "JogosJogadores",
                column: "IdJogo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogosJogadores");

            migrationBuilder.DropTable(
                name: "Jogadors");

            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
