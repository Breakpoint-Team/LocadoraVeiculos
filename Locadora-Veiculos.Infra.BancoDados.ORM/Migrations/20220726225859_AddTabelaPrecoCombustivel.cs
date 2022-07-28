using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class AddTabelaPrecoCombustivel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPrecoCombustivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecoGasolina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDiesel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoAlcool = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoGNV = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPrecoCombustivel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPrecoCombustivel");
        }
    }
}
