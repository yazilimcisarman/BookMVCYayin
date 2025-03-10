using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMVCYayin.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_KategoriId",
                table: "Books",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_KategoriId",
                table: "Books",
                column: "KategoriId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_KategoriId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_KategoriId",
                table: "Books");
        }
    }
}
