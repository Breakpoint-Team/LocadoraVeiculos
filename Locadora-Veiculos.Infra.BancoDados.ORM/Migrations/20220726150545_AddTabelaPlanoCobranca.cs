using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class AddTabelaPlanoCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiarioValorDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiarioValorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KmControladoValorDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KmControladoValorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KmControladoLimiteKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KmLivreValorDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");
        }
    }
}
