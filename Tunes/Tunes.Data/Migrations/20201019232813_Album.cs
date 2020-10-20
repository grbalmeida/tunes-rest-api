using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tunes.Data.Migrations
{
    public partial class Album : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_artistas",
                table: "artistas");

            migrationBuilder.RenameTable(
                name: "artistas",
                newName: "artista");

            migrationBuilder.AddPrimaryKey(
                name: "PK_artista",
                table: "artista",
                column: "artista_id");

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    album_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(160)", nullable: false),
                    artista_id = table.Column<int>(nullable: false),
                    data_cricao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.album_id);
                    table.ForeignKey(
                        name: "FK_album_artista_artista_id",
                        column: x => x.artista_id,
                        principalTable: "artista",
                        principalColumn: "artista_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_album_artista_id",
                table: "album",
                column: "artista_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropPrimaryKey(
                name: "PK_artista",
                table: "artista");

            migrationBuilder.RenameTable(
                name: "artista",
                newName: "artistas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_artistas",
                table: "artistas",
                column: "artista_id");
        }
    }
}
