using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAA.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPruebaBiblioteca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_Usuarios_UsuarioId",
                table: "Biblioteca");

            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_Videojuegos_VideojuegoId",
                table: "Biblioteca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Biblioteca",
                table: "Biblioteca");

            migrationBuilder.RenameTable(
                name: "Biblioteca",
                newName: "Bibliotecas");

            migrationBuilder.RenameIndex(
                name: "IX_Biblioteca_VideojuegoId",
                table: "Bibliotecas",
                newName: "IX_Bibliotecas_VideojuegoId");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Videojuegos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Contrasenya",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bibliotecas",
                table: "Bibliotecas",
                columns: new[] { "UsuarioId", "VideojuegoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_Usuarios_UsuarioId",
                table: "Bibliotecas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_Videojuegos_VideojuegoId",
                table: "Bibliotecas",
                column: "VideojuegoId",
                principalTable: "Videojuegos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_Usuarios_UsuarioId",
                table: "Bibliotecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_Videojuegos_VideojuegoId",
                table: "Bibliotecas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bibliotecas",
                table: "Bibliotecas");

            migrationBuilder.RenameTable(
                name: "Bibliotecas",
                newName: "Biblioteca");

            migrationBuilder.RenameIndex(
                name: "IX_Bibliotecas_VideojuegoId",
                table: "Biblioteca",
                newName: "IX_Biblioteca_VideojuegoId");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Videojuegos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contrasenya",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biblioteca",
                table: "Biblioteca",
                columns: new[] { "UsuarioId", "VideojuegoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_Usuarios_UsuarioId",
                table: "Biblioteca",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_Videojuegos_VideojuegoId",
                table: "Biblioteca",
                column: "VideojuegoId",
                principalTable: "Videojuegos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
