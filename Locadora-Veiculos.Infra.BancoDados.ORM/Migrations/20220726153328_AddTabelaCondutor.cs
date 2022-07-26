using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class AddTabelaCondutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(30)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(30)", nullable: false),
                    Cnh = table.Column<string>(type: "varchar(30)", nullable: false),
                    DataValidadeCnh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Endereco_Estado = table.Column<string>(type: "varchar(3)", nullable: false),
                    Endereco_Cidade = table.Column<string>(type: "varchar(300)", nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "varchar(300)", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "varchar(300)", nullable: false),
                    Endereco_Numero = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCondutor");
        }
    }
}
