using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tunes.Data.Migrations
{
    public partial class PlaylistFaixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playlist_faixa",
                columns: table => new
                {
                    playlist_id = table.Column<int>(nullable: false),
                    faixa_id = table.Column<int>(nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlist_faixa", x => new { x.playlist_id, x.faixa_id });
                    table.ForeignKey(
                        name: "FK_playlist_faixa_faixa_faixa_id",
                        column: x => x.faixa_id,
                        principalTable: "faixa",
                        principalColumn: "faixa_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playlist_faixa_playlist_playlist_id",
                        column: x => x.playlist_id,
                        principalTable: "playlist",
                        principalColumn: "playlist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_playlist_faixa_faixa_id",
                table: "playlist_faixa",
                column: "faixa_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlist_faixa");
        }
    }
}
