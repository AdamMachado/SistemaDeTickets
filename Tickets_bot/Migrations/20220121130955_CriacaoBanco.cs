using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tickets_bot.Migrations
{
    public partial class CriacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tab_pessoa_fisica",
                columns: table => new
                {
                    IdfPessoaFisica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCpf = table.Column<long>(type: "bigint", nullable: false),
                    NmePessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtaNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmlPessoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtaCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlgInativo = table.Column<bool>(type: "bit", nullable: false),
                    EmlAccount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab_pessoa_fisica", x => x.IdfPessoaFisica);
                });

            migrationBuilder.CreateTable(
                name: "Tab_tickets_bugs",
                columns: table => new
                {
                    IdfTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdfPessoaFisica = table.Column<int>(type: "int", nullable: false),
                    DesTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdfTicketSituacao = table.Column<int>(type: "int", nullable: false),
                    DtaCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NmeTicketResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlgInativo = table.Column<bool>(type: "bit", nullable: false),
                    PessoaFisicaIdfPessoaFisica = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab_tickets_bugs", x => x.IdfTicket);
                    table.ForeignKey(
                        name: "FK_Tab_tickets_bugs_Tab_pessoa_fisica_PessoaFisicaIdfPessoaFisica",
                        column: x => x.PessoaFisicaIdfPessoaFisica,
                        principalTable: "Tab_pessoa_fisica",
                        principalColumn: "IdfPessoaFisica",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tab_tickets_bugs_PessoaFisicaIdfPessoaFisica",
                table: "Tab_tickets_bugs",
                column: "PessoaFisicaIdfPessoaFisica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tab_tickets_bugs");

            migrationBuilder.DropTable(
                name: "Tab_pessoa_fisica");
        }
    }
}
