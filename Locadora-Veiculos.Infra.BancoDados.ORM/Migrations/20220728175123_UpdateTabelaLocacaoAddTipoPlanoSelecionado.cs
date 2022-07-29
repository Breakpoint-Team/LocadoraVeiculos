using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class UpdateTabelaLocacaoAddTipoPlanoSelecionado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPlanoSelecionado = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_TBLocacao_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
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
                    TaxasSelecionadasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxa", x => new { x.LocacoesId, x.TaxasSelecionadasId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBLocacao_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                        column: x => x.TaxasSelecionadasId,
                        principalTable: "TBTaxa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa",
                column: "TaxasSelecionadasId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_CondutorId",
                table: "TBLocacao",
                column: "CondutorId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoTaxa");

            migrationBuilder.DropTable(
                name: "TBLocacao");
        }
    }
}
