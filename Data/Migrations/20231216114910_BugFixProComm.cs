using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class BugFixProComm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Comments_CommentID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CommentID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductID",
                table: "Comments",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductID",
                table: "Comments",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CommentID",
                table: "Products",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Comments_CommentID",
                table: "Products",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "CommentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
