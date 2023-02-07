using Microsoft.EntityFrameworkCore.Migrations;

namespace APIAA.Migrations
{

    public partial class Initial : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideojuegoBBDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).
                    Annotation("SqlServer:Identity", "1,1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioVenta = table.Column<int>(type: "decimal", nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false),

                    //Controlar unidades 0 y negativo
                    Agotado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videojuegos", x => x.Id);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videojuegos");
        }
    }

}