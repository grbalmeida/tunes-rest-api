using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tunes.Data.Migrations
{
    public partial class ItemNotaFiscal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item_nota_fiscal",
                columns: table => new
                {
                    item_nota_fiscal_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preco_unitario = table.Column<decimal>(type: "numeric(10, 2)", nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    nota_fiscal_id = table.Column<int>(nullable: false),
                    faixa_id = table.Column<int>(nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_nota_fiscal", x => x.item_nota_fiscal_id);
                    table.ForeignKey(
                        name: "FK_item_nota_fiscal_faixa_faixa_id",
                        column: x => x.faixa_id,
                        principalTable: "faixa",
                        principalColumn: "faixa_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_nota_fiscal_nota_fiscal_nota_fiscal_id",
                        column: x => x.nota_fiscal_id,
                        principalTable: "nota_fiscal",
                        principalColumn: "nota_fiscal_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_nota_fiscal_faixa_id",
                table: "item_nota_fiscal",
                column: "faixa_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_nota_fiscal_nota_fiscal_id",
                table: "item_nota_fiscal",
                column: "nota_fiscal_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_nota_fiscal");
        }
    }
}
