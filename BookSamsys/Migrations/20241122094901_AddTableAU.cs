using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSamsys.Migrations
{
    /// <inheritdoc />
    public partial class AddTableAU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autores_IdAuthor",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livros",
                table: "Livros");

            migrationBuilder.RenameTable(
                name: "Livros",
                newName: "Livros2");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_IdAuthor",
                table: "Livros2",
                newName: "IX_Livros2_IdAuthor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livros2",
                table: "Livros2",
                column: "ISBN");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livros2",
                table: "Livros2");

            migrationBuilder.RenameTable(
                name: "Livros2",
                newName: "Livros");

            migrationBuilder.RenameIndex(
                name: "IX_Livros2_IdAuthor",
                table: "Livros",
                newName: "IX_Livros_IdAuthor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livros",
                table: "Livros",
                column: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Autores_IdAuthor",
                table: "Livros",
                column: "IdAuthor",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
