using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAA.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Videojuegos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Biblioteca",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    VideojuegoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca", x => new { x.UsuarioId, x.VideojuegoId });
                    table.ForeignKey(
                        name: "FK_Biblioteca_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Biblioteca_Videojuegos_VideojuegoId",
                        column: x => x.VideojuegoId,
                        principalTable: "Videojuegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_VideojuegoId",
                table: "Transacciones",
                column: "VideojuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_VideojuegoId",
                table: "Biblioteca",
                column: "VideojuegoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Videojuegos_VideojuegoId",
                table: "Transacciones",
                column: "VideojuegoId",
                principalTable: "Videojuegos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Videojuegos_VideojuegoId",
                table: "Transacciones");

            migrationBuilder.DropTable(
                name: "Biblioteca");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_VideojuegoId",
                table: "Transacciones");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Videojuegos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
