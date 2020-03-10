using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai.Senatur.WebApi.Migrations
{
    public partial class BancoSenatur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id_Cidade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    NomeCidade = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id_Cidade);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuario",
                columns: table => new
                {
                    Id_TipoUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "VARCHAR (100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.Id_TipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    Id_Pacote = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomePacote = table.Column<string>(type: "VARCHAR (100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(MAX)", maxLength: 1500, nullable: false),
                    DataIda = table.Column<DateTime>(type: "DATE", nullable: false),
                    DataVolta = table.Column<DateTime>(type: "DATE", nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL (18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    Fk_NomeCidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.Id_Pacote);
                    table.ForeignKey(
                        name: "FK_Pacotes_Cidades_Fk_NomeCidade",
                        column: x => x.Fk_NomeCidade,
                        principalTable: "Cidades",
                        principalColumn: "Id_Cidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VARCHAR150 = table.Column<string>(name: "VARCHAR(150)", maxLength: 150, nullable: false),
                    VARCHAR30 = table.Column<string>(name: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Fk_TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuario_Fk_TipoUsuario",
                        column: x => x.Fk_TipoUsuario,
                        principalTable: "TiposUsuario",
                        principalColumn: "Id_TipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id_Cidade", "Estado", "NomeCidade" },
                values: new object[,]
                {
                    { 1, "Bahia", "Salvador" },
                    { 2, "Mato Grosso do sul", "Bonito" }
                });

            migrationBuilder.InsertData(
                table: "TiposUsuario",
                columns: new[] { "Id_TipoUsuario", "Titulo" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "Id_Pacote", "Ativo", "DataIda", "DataVolta", "Descricao", "Fk_NomeCidade", "NomePacote", "Preco" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "O que não falta em Salvador são atrações.Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região.A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros.O Pelourinho e o Elevador são alguns dos principais pontos de visitação.", 1, "SALVADOR - 5 DIAS / 4 DIÁRIAS", 854.00m },
                    { 2, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.", 1, "RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS", 1826.00m },
                    { 3, false, new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas d'água da região", 2, "BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS", 1004.00m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id_Usuario", "VARCHAR(150)", "Fk_TipoUsuario", "VARCHAR(30)" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", 1, "admin" },
                    { 2, "cliente@cliente.com", 2, "cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_NomeCidade",
                table: "Cidades",
                column: "NomeCidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_Fk_NomeCidade",
                table: "Pacotes",
                column: "Fk_NomeCidade");

            migrationBuilder.CreateIndex(
                name: "IX_TiposUsuario_Titulo",
                table: "TiposUsuario",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_VARCHAR(150)",
                table: "Usuarios",
                column: "VARCHAR(150)",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Fk_TipoUsuario",
                table: "Usuarios",
                column: "Fk_TipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "TiposUsuario");
        }
    }
}
