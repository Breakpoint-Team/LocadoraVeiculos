using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class DefinindoAhExclusaoDaTabelaPlanoCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca");

            migrationBuilder.DropIndex(
                name: "IX_TBPlanoCobranca_GrupoVeiculosId",
                table: "TBPlanoCobranca");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca");

            migrationBuilder.DropIndex(
                name: "IX_TBPlanoCobranca_GrupoVeiculosId",
                table: "TBPlanoCobranca");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_TBGrupoVeiculos_GrupoVeiculosId",
                table: "TBPlanoCobranca",
                column: "GrupoVeiculosId",
                principalTable: "TBGrupoVeiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
