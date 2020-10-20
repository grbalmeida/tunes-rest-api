using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tunes.Data.Migrations
{
    public partial class Funcionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    funcionario_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primeiro_nome = table.Column<string>(type: "varchar(20)", nullable: false),
                    sobrenome = table.Column<string>(type: "varchar(20)", nullable: false),
                    titulo = table.Column<string>(type: "varchar(30)", nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_admissao = table.Column<DateTime>(type: "datetime", nullable: false),
                    endereco = table.Column<string>(type: "varchar(70)", nullable: true),
                    cidade = table.Column<string>(type: "varchar(40)", nullable: true),
                    estado = table.Column<string>(type: "varchar(40)", nullable: true),
                    pais = table.Column<string>(type: "varchar(40)", nullable: true),
                    cep = table.Column<string>(type: "varchar(10)", nullable: true),
                    fone = table.Column<string>(type: "varchar(24)", nullable: true),
                    fax = table.Column<string>(type: "varchar(24)", nullable: true),
                    email = table.Column<string>(type: "varchar(60)", nullable: true),
                    se_reporta_a = table.Column<int>(nullable: true),
                    data_criacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.funcionario_id);
                    table.ForeignKey(
                        name: "FK_funcionario_funcionario_se_reporta_a",
                        column: x => x.se_reporta_a,
                        principalTable: "funcionario",
                        principalColumn: "funcionario_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_se_reporta_a",
                table: "funcionario",
                column: "se_reporta_a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionario");
        }
    }
}
