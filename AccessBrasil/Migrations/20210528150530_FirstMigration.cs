using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessBrasil.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbCarro",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaCodigo = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCarro", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "DbMarca",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbMarca", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbCarro");

            migrationBuilder.DropTable(
                name: "DbMarca");
        }
    }
}
