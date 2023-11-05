using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class inti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeblogCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeblogCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Weblogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeblogCategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weblogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Weblogs_WeblogCategories_WeblogCategoryId",
                        column: x => x.WeblogCategoryId,
                        principalTable: "WeblogCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weblogs_WeblogCategoryId",
                table: "Weblogs",
                column: "WeblogCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weblogs");

            migrationBuilder.DropTable(
                name: "WeblogCategories");
        }
    }
}
