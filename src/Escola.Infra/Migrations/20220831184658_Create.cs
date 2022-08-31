using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Infra.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUNO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: true),
                    SOBRENOME = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true),
                    EMAIL = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoID", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_Matricula",
                table: "ALUNO",
                column: "Matricula",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNO");
        }
    }
}
