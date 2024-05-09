using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeAlunos.Migrations
{
    public partial class InitDataBaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "InstituicoesEnsino",
                columns: table => new
                {
                    InstituicaoEnsinoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituicoesEnsino", x => x.InstituicaoEnsinoId);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.CidadeId);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId");
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    CidadeId = table.Column<int>(type: "int", nullable: true),
                    InstituicaoEnsinoId = table.Column<int>(type: "int", nullable: true),
                    NomeCurso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "CidadeId");
                    table.ForeignKey(
                        name: "FK_Aluno_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId");
                    table.ForeignKey(
                        name: "FK_Aluno_InstituicoesEnsino_InstituicaoEnsinoId",
                        column: x => x.InstituicaoEnsinoId,
                        principalTable: "InstituicoesEnsino",
                        principalColumn: "InstituicaoEnsinoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_CidadeId",
                table: "Aluno",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_EstadoId",
                table: "Aluno",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_InstituicaoEnsinoId",
                table: "Aluno",
                column: "InstituicaoEnsinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "InstituicoesEnsino");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
