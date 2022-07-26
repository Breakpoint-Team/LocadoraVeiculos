using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class AddTabelaFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    Login = table.Column<string>(type: "varchar(300)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(300)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EhAdmin = table.Column<bool>(type: "bit", nullable: false),
                    EstaAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBFuncionario");
        }
    }
}
