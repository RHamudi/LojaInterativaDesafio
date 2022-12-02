using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaInterativa.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCategoria = table.Column<string>(type: "NVARCHAR(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    idFabricante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeFabricante = table.Column<string>(type: "NVARCHAR(180)", maxLength: 180, nullable: false),
                    fantasiaFabricante = table.Column<string>(type: "NVARCHAR(180)", maxLength: 180, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.idFabricante);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoProduto = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    precoProduto = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    idFabricante = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.idProduto);
                    table.ForeignKey(
                        name: "FK_PRODUTO_CATEGORIA",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_FABRICANTE",
                        column: x => x.idFabricante,
                        principalTable: "Fabricante",
                        principalColumn: "idFabricante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_idCategoria",
                table: "Produto",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_idFabricante",
                table: "Produto",
                column: "idFabricante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Fabricante");
        }
    }
}
