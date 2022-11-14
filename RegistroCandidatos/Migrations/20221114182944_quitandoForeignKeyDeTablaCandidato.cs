using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroCandidatos.Migrations
{
    public partial class quitandoForeignKeyDeTablaCandidato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidato_Genero_ID_Genero",
                table: "Candidato");

            migrationBuilder.DropIndex(
                name: "IX_Candidato_ID_Genero",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "ID_Genero",
                table: "Candidato");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Genero",
                newName: "NombreGenero");

            migrationBuilder.AddColumn<int>(
                name: "GeneroID_Genero",
                table: "Candidato",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidato_Genero_GeneroID_Genero",
                table: "Candidato");

            migrationBuilder.DropIndex(
                name: "IX_Candidato_GeneroID_Genero",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "GeneroID_Genero",
                table: "Candidato");

            migrationBuilder.RenameColumn(
                name: "NombreGenero",
                table: "Genero",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "ID_Genero",
                table: "Candidato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_ID_Genero",
                table: "Candidato",
                column: "ID_Genero");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidato_Genero_ID_Genero",
                table: "Candidato",
                column: "ID_Genero",
                principalTable: "Genero",
                principalColumn: "ID_Genero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
