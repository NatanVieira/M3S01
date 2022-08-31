using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Infra.Migrations
{
    public partial class UpgradeMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOLETIM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ORDE_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoletimID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOLETIM_ALUNO_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "ALUNO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATERIA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TURMA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURSO = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NOTAS_MATERIAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoletimId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    NOTA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasMateriasId", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTAS_MATERIAS_BOLETIM_BoletimId",
                        column: x => x.BoletimId,
                        principalTable: "BOLETIM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTAS_MATERIAS_MATERIA_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "MATERIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    AlunosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => new { x.AlunosId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_AlunoTurma_ALUNO_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "ALUNO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_TURMA_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "TURMA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_TurmasId",
                table: "AlunoTurma",
                column: "TurmasId");

            migrationBuilder.CreateIndex(
                name: "IX_BOLETIM_AlunoId",
                table: "BOLETIM",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTAS_MATERIAS_BoletimId",
                table: "NOTAS_MATERIAS",
                column: "BoletimId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTAS_MATERIAS_MateriaId",
                table: "NOTAS_MATERIAS",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "NOTAS_MATERIAS");

            migrationBuilder.DropTable(
                name: "TURMA");

            migrationBuilder.DropTable(
                name: "BOLETIM");

            migrationBuilder.DropTable(
                name: "MATERIA");
        }
    }
}
