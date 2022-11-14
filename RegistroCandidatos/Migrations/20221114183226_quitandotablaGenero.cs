using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroCandidatos.Migrations
{
    public partial class quitandotablaGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidato_Genero_GeneroID_Genero",
                table: "Candidato");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropIndex(
                name: "IX_Candidato_GeneroID_Genero",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "GeneroID_Genero",
                table: "Candidato");

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Candidato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Candidato");

            migrationBuilder.AddColumn<int>(
                name: "GeneroID_Genero",
                table: "Candidato",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    ID_Genero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGenero = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.ID_Genero);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_GeneroID_Genero",
                table: "Candidato",
                column: "GeneroID_Genero");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidato_Genero_GeneroID_Genero",
                table: "Candidato",
                column: "GeneroID_Genero",
                principalTable: "Genero",
                principalColumn: "ID_Genero");
        }
    }
}
