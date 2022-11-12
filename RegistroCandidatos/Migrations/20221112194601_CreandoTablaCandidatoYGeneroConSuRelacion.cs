using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroCandidatos.Migrations
{
    public partial class CreandoTablaCandidatoYGeneroConSuRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    ID_Genero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.ID_Genero);
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    ID_Candidato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Genero = table.Column<int>(type: "int", nullable: false),
                    TrabajoActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectativaSalarial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.ID_Candidato);
                    table.ForeignKey(
                        name: "FK_Candidato_Genero_ID_Genero",
                        column: x => x.ID_Genero,
                        principalTable: "Genero",
                        principalColumn: "ID_Genero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_ID_Genero",
                table: "Candidato",
                column: "ID_Genero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
