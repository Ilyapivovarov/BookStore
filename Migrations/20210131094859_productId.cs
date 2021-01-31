using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class productId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Products_ProductId",
                table: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Basket_ProductId",
                table: "Basket");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Basket",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Basket",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ProductId",
                table: "Basket",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Products_ProductId",
                table: "Basket",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
