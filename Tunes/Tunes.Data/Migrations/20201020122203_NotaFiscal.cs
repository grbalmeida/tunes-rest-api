using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tunes.Data.Migrations
{
    public partial class NotaFiscal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data_criacao",
                table: "cliente",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.CreateTable(
                name: "nota_fiscal",
                columns: table => new
                {
                    nota_fiscal_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_nota_fiscal = table.Column<DateTime>(type: "datetime", nullable: false),
                    endereco = table.Column<string>(type: "varchar(70)", nullable: true),
                    cidade = table.Column<string>(type: "varchar(40)", nullable: true),
                    estado = table.Column<string>(type: "varchar(40)", nullable: true),
                    pais = table.Column<string>(type: "varchar(40)", nullable: true),
                    cep = table.Column<string>(type: "varchar(10)", nullable: true),
                    total = table.Column<decimal>(type: "numeric(10, 2)", nullable: false),
                    cliente_id = table.Column<int>(nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nota_fiscal", x => x.nota_fiscal_id);
                    table.ForeignKey(
                        name: "FK_nota_fiscal_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "cliente_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nota_fiscal_cliente_id",
                table: "nota_fiscal",
                column: "cliente_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nota_fiscal");

            migrationBuilder.DropColumn(
                name: "data_criacao",
                table: "cliente");
        }
    }
}
