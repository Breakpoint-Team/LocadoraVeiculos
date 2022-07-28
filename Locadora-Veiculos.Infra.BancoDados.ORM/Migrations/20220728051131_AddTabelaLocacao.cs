using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class AddTabelaLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TBCondutor",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotalPrevisto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuilometragemInicialVeiculo = table.Column<int>(type: "int", nullable: false),
                    QuilometragemFinalVeiculo = table.Column<int>(type: "int", nullable: true),
                    DataDevolucaoEfetiva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NivelTanqueDevolucao = table.Column<int>(type: "int", nullable: true),
                    ValorTotalEfetivo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StatusLocacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBGrupoVeiculos_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBPlanoCobranca_PlanoCobrancaId",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "TBPlanoCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocacaoTaxa",
                columns: table => new
                {
                    LocacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxa", x => new { x.LocacoesId, x.TaxasId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBLocacao_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBTaxa_TaxasId",
                        column: x => x.TaxasId,
                        principalTable: "TBTaxa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_LocacaoId",
                table: "TBCondutor",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_TaxasId",
                table: "LocacaoTaxa",
                column: "TaxasId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_ClienteId",
                table: "TBLocacao",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_GrupoVeiculosId",
                table: "TBLocacao",
                column: "GrupoVeiculosId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_PlanoCobrancaId",
                table: "TBLocacao",
                column: "PlanoCobrancaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBLocacao_LocacaoId",
                table: "TBCondutor",
                column: "LocacaoId",
                principalTable: "TBLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBLocacao_LocacaoId",
                table: "TBCondutor");

            migrationBuilder.DropTable(
                name: "LocacaoTaxa");

            migrationBuilder.DropTable(
                name: "TBLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TBCondutor_LocacaoId",
                table: "TBCondutor");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TBCondutor");
        }
    }
}
