using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroCandidatos.Migrations
{
    public partial class ConvirtiendoCampoCedulaEnValorUnicoEnBaseDeDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Candidato",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_Cedula",
                table: "Candidato",
                column: "Cedula",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Candidato_Cedula",
                table: "Candidato");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Candidato",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
