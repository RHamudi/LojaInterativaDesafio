using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaInterativa.Migrations
{
    public partial class funcCateg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_CATEGORIA",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Produto_idCategoria",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "idCategoria",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "fantasiaFabricante",
                table: "Fabricante");

            migrationBuilder.AddColumn<string>(
                name: "categoriaProduto",
                table: "Produto",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "categoria1",
                table: "Fabricante",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "categoria2",
                table: "Fabricante",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "categoria3",
                table: "Fabricante",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoriaProduto",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "categoria1",
                table: "Fabricante");

            migrationBuilder.DropColumn(
                name: "categoria2",
                table: "Fabricante");

            migrationBuilder.DropColumn(
                name: "categoria3",
                table: "Fabricante");

            migrationBuilder.AddColumn<int>(
                name: "idCategoria",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "fantasiaFabricante",
                table: "Fabricante",
                type: "NVARCHAR(180)",
                maxLength: 180,
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Produto_idCategoria",
                table: "Produto",
                column: "idCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_CATEGORIA",
                table: "Produto",
                column: "idCategoria",
                principalTable: "Categoria",
                principalColumn: "idCategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
