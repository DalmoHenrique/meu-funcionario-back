using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace meu_funcionario_back.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Salario = table.Column<double>(nullable: false),
                    Genero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "DataNascimento", "Endereco", "Genero", "Nome", "Salario" },
                values: new object[] { 1, new DateTime(2020, 9, 28, 14, 49, 12, 912, DateTimeKind.Local).AddTicks(227), "Rua José, 19", "Masculino", "Dalmo", 2020.2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
