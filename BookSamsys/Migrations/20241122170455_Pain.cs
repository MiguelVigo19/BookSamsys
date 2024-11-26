using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSamsys.Migrations
{
    /// <inheritdoc />
    public partial class Pain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Livros2_IdAuthor",
                table: "Livros2",
                column: "IdAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros2_Autores_IdAuthor",
                table: "Livros2",
                column: "IdAuthor",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros2_Autores_IdAuthor",
                table: "Livros2");

            migrationBuilder.DropIndex(
                name: "IX_Livros2_IdAuthor",
                table: "Livros2");
        }
    }
}
