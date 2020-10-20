using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tunes.Data.Migrations
{
    public partial class Faixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "faixa",
                columns: table => new
                {
                    faixa_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    compositor = table.Column<string>(type: "varchar(220)", nullable: true),
                    milissegundos = table.Column<int>(nullable: false),
                    bytes = table.Column<int>(nullable: false),
                    preco_unitario = table.Column<decimal>(type: "numeric(10, 2)", nullable: false),
                    album_id = table.Column<int>(nullable: true),
                    tipo_midia_id = table.Column<int>(nullable: false),
                    genero_id = table.Column<int>(nullable: true),
                    data_criacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faixa", x => x.faixa_id);
                    table.ForeignKey(
                        name: "FK_faixa_album_album_id",
                        column: x => x.album_id,
                        principalTable: "album",
                        principalColumn: "album_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_faixa_genero_genero_id",
                        column: x => x.genero_id,
                        principalTable: "genero",
                        principalColumn: "genero_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_faixa_tipo_midia_tipo_midia_id",
                        column: x => x.tipo_midia_id,
                        principalTable: "tipo_midia",
                        principalColumn: "tipo_midia_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_faixa_album_id",
                table: "faixa",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_faixa_genero_id",
                table: "faixa",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_faixa_tipo_midia_id",
                table: "faixa",
                column: "tipo_midia_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "faixa");
        }
    }
}
