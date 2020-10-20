using Microsoft.EntityFrameworkCore.Migrations;

namespace Tunes.Data.Migrations
{
    public partial class Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cliente_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primeiro_nome = table.Column<string>(type: "varchar(40)", nullable: false),
                    sobrenome = table.Column<string>(type: "varchar(20)", nullable: false),
                    empresa = table.Column<string>(type: "varchar(80)", nullable: true),
                    endereco = table.Column<string>(type: "varchar(70)", nullable: true),
                    cidade = table.Column<string>(type: "varchar(40)", nullable: true),
                    estado = table.Column<string>(type: "varchar(40)", nullable: true),
                    pais = table.Column<string>(type: "varchar(40)", nullable: true),
                    cep = table.Column<string>(type: "varchar(10)", nullable: true),
                    fone = table.Column<string>(type: "varchar(24)", nullable: true),
                    fax = table.Column<string>(type: "varchar(24)", nullable: true),
                    email = table.Column<string>(type: "varchar(60)", nullable: false),
                    suporte_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.cliente_id);
                    table.ForeignKey(
                        name: "FK_cliente_funcionario_suporte_id",
                        column: x => x.suporte_id,
                        principalTable: "funcionario",
                        principalColumn: "funcionario_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_suporte_id",
                table: "cliente",
                column: "suporte_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
