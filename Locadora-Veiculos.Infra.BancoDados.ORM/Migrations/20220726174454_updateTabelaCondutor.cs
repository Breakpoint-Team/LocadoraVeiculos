using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Migrations
{
    public partial class updateTabelaCondutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId1",
                table: "TBCondutor",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId1",
                table: "TBCondutor",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId1",
                table: "TBCondutor",
                column: "ClienteId1",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor");

            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId1",
                table: "TBCondutor");

            migrationBuilder.DropIndex(
                name: "IX_TBCondutor_ClienteId1",
                table: "TBCondutor");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "TBCondutor");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_TBCliente_ClienteId",
                table: "TBCondutor",
                column: "ClienteId",
                principalTable: "TBCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
