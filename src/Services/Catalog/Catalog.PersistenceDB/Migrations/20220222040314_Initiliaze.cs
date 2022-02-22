using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.PersistenceDB.Migrations
{
    public partial class Initiliaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Descripción del producto 1", "Producto 1", 434m },
                    { 73, "Descripción del producto 73", "Producto 73", 603m },
                    { 72, "Descripción del producto 72", "Producto 72", 486m },
                    { 71, "Descripción del producto 71", "Producto 71", 169m },
                    { 70, "Descripción del producto 70", "Producto 70", 146m },
                    { 69, "Descripción del producto 69", "Producto 69", 934m },
                    { 68, "Descripción del producto 68", "Producto 68", 971m },
                    { 67, "Descripción del producto 67", "Producto 67", 864m },
                    { 66, "Descripción del producto 66", "Producto 66", 731m },
                    { 65, "Descripción del producto 65", "Producto 65", 166m },
                    { 64, "Descripción del producto 64", "Producto 64", 486m },
                    { 63, "Descripción del producto 63", "Producto 63", 843m },
                    { 62, "Descripción del producto 62", "Producto 62", 178m },
                    { 61, "Descripción del producto 61", "Producto 61", 565m },
                    { 60, "Descripción del producto 60", "Producto 60", 520m },
                    { 59, "Descripción del producto 59", "Producto 59", 751m },
                    { 58, "Descripción del producto 58", "Producto 58", 932m },
                    { 57, "Descripción del producto 57", "Producto 57", 762m },
                    { 56, "Descripción del producto 56", "Producto 56", 938m },
                    { 55, "Descripción del producto 55", "Producto 55", 993m },
                    { 54, "Descripción del producto 54", "Producto 54", 693m },
                    { 53, "Descripción del producto 53", "Producto 53", 505m },
                    { 74, "Descripción del producto 74", "Producto 74", 978m },
                    { 52, "Descripción del producto 52", "Producto 52", 724m },
                    { 75, "Descripción del producto 75", "Producto 75", 507m },
                    { 77, "Descripción del producto 77", "Producto 77", 646m },
                    { 98, "Descripción del producto 98", "Producto 98", 462m },
                    { 97, "Descripción del producto 97", "Producto 97", 114m },
                    { 96, "Descripción del producto 96", "Producto 96", 119m },
                    { 95, "Descripción del producto 95", "Producto 95", 543m },
                    { 94, "Descripción del producto 94", "Producto 94", 439m },
                    { 93, "Descripción del producto 93", "Producto 93", 270m },
                    { 92, "Descripción del producto 92", "Producto 92", 306m },
                    { 91, "Descripción del producto 91", "Producto 91", 647m },
                    { 90, "Descripción del producto 90", "Producto 90", 213m },
                    { 89, "Descripción del producto 89", "Producto 89", 969m },
                    { 88, "Descripción del producto 88", "Producto 88", 383m },
                    { 87, "Descripción del producto 87", "Producto 87", 808m },
                    { 86, "Descripción del producto 86", "Producto 86", 348m },
                    { 85, "Descripción del producto 85", "Producto 85", 766m },
                    { 84, "Descripción del producto 84", "Producto 84", 271m },
                    { 83, "Descripción del producto 83", "Producto 83", 774m },
                    { 82, "Descripción del producto 82", "Producto 82", 334m },
                    { 81, "Descripción del producto 81", "Producto 81", 856m },
                    { 80, "Descripción del producto 80", "Producto 80", 399m },
                    { 79, "Descripción del producto 79", "Producto 79", 341m },
                    { 78, "Descripción del producto 78", "Producto 78", 149m },
                    { 76, "Descripción del producto 76", "Producto 76", 815m },
                    { 51, "Descripción del producto 51", "Producto 51", 907m },
                    { 50, "Descripción del producto 50", "Producto 50", 360m },
                    { 49, "Descripción del producto 49", "Producto 49", 615m },
                    { 22, "Descripción del producto 22", "Producto 22", 495m },
                    { 21, "Descripción del producto 21", "Producto 21", 673m },
                    { 20, "Descripción del producto 20", "Producto 20", 605m },
                    { 19, "Descripción del producto 19", "Producto 19", 987m },
                    { 18, "Descripción del producto 18", "Producto 18", 464m },
                    { 17, "Descripción del producto 17", "Producto 17", 409m },
                    { 16, "Descripción del producto 16", "Producto 16", 309m },
                    { 15, "Descripción del producto 15", "Producto 15", 456m },
                    { 14, "Descripción del producto 14", "Producto 14", 986m },
                    { 13, "Descripción del producto 13", "Producto 13", 934m },
                    { 12, "Descripción del producto 12", "Producto 12", 842m },
                    { 11, "Descripción del producto 11", "Producto 11", 944m },
                    { 10, "Descripción del producto 10", "Producto 10", 139m },
                    { 9, "Descripción del producto 9", "Producto 9", 160m },
                    { 8, "Descripción del producto 8", "Producto 8", 375m },
                    { 7, "Descripción del producto 7", "Producto 7", 468m },
                    { 6, "Descripción del producto 6", "Producto 6", 549m },
                    { 5, "Descripción del producto 5", "Producto 5", 689m },
                    { 4, "Descripción del producto 4", "Producto 4", 267m },
                    { 3, "Descripción del producto 3", "Producto 3", 252m },
                    { 2, "Descripción del producto 2", "Producto 2", 155m },
                    { 23, "Descripción del producto 23", "Producto 23", 392m },
                    { 24, "Descripción del producto 24", "Producto 24", 319m },
                    { 25, "Descripción del producto 25", "Producto 25", 515m },
                    { 26, "Descripción del producto 26", "Producto 26", 268m },
                    { 48, "Descripción del producto 48", "Producto 48", 749m },
                    { 47, "Descripción del producto 47", "Producto 47", 411m },
                    { 46, "Descripción del producto 46", "Producto 46", 216m },
                    { 45, "Descripción del producto 45", "Producto 45", 977m },
                    { 44, "Descripción del producto 44", "Producto 44", 343m },
                    { 43, "Descripción del producto 43", "Producto 43", 849m },
                    { 42, "Descripción del producto 42", "Producto 42", 858m },
                    { 41, "Descripción del producto 41", "Producto 41", 197m },
                    { 40, "Descripción del producto 40", "Producto 40", 108m },
                    { 39, "Descripción del producto 39", "Producto 39", 860m },
                    { 99, "Descripción del producto 99", "Producto 99", 277m },
                    { 38, "Descripción del producto 38", "Producto 38", 922m },
                    { 36, "Descripción del producto 36", "Producto 36", 410m },
                    { 35, "Descripción del producto 35", "Producto 35", 152m },
                    { 34, "Descripción del producto 34", "Producto 34", 962m },
                    { 33, "Descripción del producto 33", "Producto 33", 977m },
                    { 32, "Descripción del producto 32", "Producto 32", 313m },
                    { 31, "Descripción del producto 31", "Producto 31", 972m },
                    { 30, "Descripción del producto 30", "Producto 30", 673m },
                    { 29, "Descripción del producto 29", "Producto 29", 532m },
                    { 28, "Descripción del producto 28", "Producto 28", 390m },
                    { 27, "Descripción del producto 27", "Producto 27", 983m },
                    { 37, "Descripción del producto 37", "Producto 37", 239m },
                    { 100, "Descripción del producto 100", "Producto 100", 346m }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 19 },
                    { 73, 73, 19 },
                    { 72, 72, 17 },
                    { 71, 71, 9 },
                    { 70, 70, 2 },
                    { 69, 69, 3 },
                    { 68, 68, 6 },
                    { 67, 67, 14 },
                    { 66, 66, 17 },
                    { 65, 65, 18 },
                    { 64, 64, 18 },
                    { 63, 63, 8 },
                    { 62, 62, 2 },
                    { 61, 61, 18 },
                    { 60, 60, 18 },
                    { 59, 59, 14 },
                    { 58, 58, 2 },
                    { 57, 57, 17 },
                    { 56, 56, 3 },
                    { 55, 55, 2 },
                    { 54, 54, 19 },
                    { 53, 53, 11 },
                    { 74, 74, 16 },
                    { 52, 52, 14 },
                    { 75, 75, 18 },
                    { 77, 77, 13 },
                    { 98, 98, 3 },
                    { 97, 97, 1 },
                    { 96, 96, 8 },
                    { 95, 95, 5 },
                    { 94, 94, 16 },
                    { 93, 93, 3 },
                    { 92, 92, 7 },
                    { 91, 91, 3 },
                    { 90, 90, 14 },
                    { 89, 89, 10 },
                    { 88, 88, 6 },
                    { 87, 87, 3 },
                    { 86, 86, 11 },
                    { 85, 85, 14 },
                    { 84, 84, 18 },
                    { 83, 83, 15 },
                    { 82, 82, 12 },
                    { 81, 81, 6 },
                    { 80, 80, 2 },
                    { 79, 79, 11 },
                    { 78, 78, 14 },
                    { 76, 76, 5 },
                    { 51, 51, 15 },
                    { 50, 50, 1 },
                    { 49, 49, 12 },
                    { 22, 22, 16 },
                    { 21, 21, 15 },
                    { 20, 20, 10 },
                    { 19, 19, 19 },
                    { 18, 18, 14 },
                    { 17, 17, 14 },
                    { 16, 16, 0 },
                    { 15, 15, 3 },
                    { 14, 14, 1 },
                    { 13, 13, 19 },
                    { 12, 12, 0 },
                    { 11, 11, 12 },
                    { 10, 10, 5 },
                    { 9, 9, 8 },
                    { 8, 8, 8 },
                    { 7, 7, 11 },
                    { 6, 6, 5 },
                    { 5, 5, 4 },
                    { 4, 4, 12 },
                    { 3, 3, 10 },
                    { 2, 2, 8 },
                    { 23, 23, 11 },
                    { 24, 24, 7 },
                    { 25, 25, 17 },
                    { 26, 26, 6 },
                    { 48, 48, 14 },
                    { 47, 47, 0 },
                    { 46, 46, 14 },
                    { 45, 45, 15 },
                    { 44, 44, 17 },
                    { 43, 43, 2 },
                    { 42, 42, 10 },
                    { 41, 41, 11 },
                    { 40, 40, 3 },
                    { 39, 39, 14 },
                    { 99, 99, 18 },
                    { 38, 38, 17 },
                    { 36, 36, 1 },
                    { 35, 35, 17 },
                    { 34, 34, 12 },
                    { 33, 33, 5 },
                    { 32, 32, 15 },
                    { 31, 31, 6 },
                    { 30, 30, 9 },
                    { 29, 29, 19 },
                    { 28, 28, 8 },
                    { 27, 27, 7 },
                    { 37, 37, 10 },
                    { 100, 100, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductInStockId",
                table: "Stocks",
                column: "ProductInStockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
