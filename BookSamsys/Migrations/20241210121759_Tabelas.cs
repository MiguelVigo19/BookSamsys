using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSamsys.Migrations
{
    /// <inheritdoc />
    public partial class Tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros2",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAuthor = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros2", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Livros2_Autores_IdAuthor",
                        column: x => x.IdAuthor,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros2_IdAuthor",
                table: "Livros2",
                column: "IdAuthor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros2");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
