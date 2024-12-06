using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalHub.Migrations
{
    /// <inheritdoc />
    public partial class Added_CategoriaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCategoriaProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCategoriaProdutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCategoriaProdutoProduto",
                columns: table => new
                {
                    CategoriaProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCategoriaProdutoProduto", x => new { x.CategoriaProdutoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_AppCategoriaProdutoProduto_AppCategoriaProdutos_CategoriaPr~",
                        column: x => x.CategoriaProdutoId,
                        principalTable: "AppCategoriaProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCategoriaProdutoProduto_AppProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "AppProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCategoriaProdutoProduto_CategoriaProdutoId_ProdutoId",
                table: "AppCategoriaProdutoProduto",
                columns: new[] { "CategoriaProdutoId", "ProdutoId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppCategoriaProdutoProduto_ProdutoId",
                table: "AppCategoriaProdutoProduto",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCategoriaProdutoProduto");

            migrationBuilder.DropTable(
                name: "AppCategoriaProdutos");
        }
    }
}
