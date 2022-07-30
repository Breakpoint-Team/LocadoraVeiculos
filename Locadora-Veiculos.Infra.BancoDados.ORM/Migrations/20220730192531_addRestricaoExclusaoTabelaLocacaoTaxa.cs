using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class addRestricaoExclusaoTabelaLocacaoTaxa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa");

            migrationBuilder.DropTable(
                name: "TBPrecoCombustivel");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa",
                column: "TaxasSelecionadasId",
                principalTable: "TBTaxa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa");

            migrationBuilder.CreateTable(
                name: "TBPrecoCombustivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecoAlcool = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDiesel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoGNV = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoGasolina = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPrecoCombustivel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoTaxa_TBTaxa_TaxasSelecionadasId",
                table: "LocacaoTaxa",
                column: "TaxasSelecionadasId",
                principalTable: "TBTaxa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
