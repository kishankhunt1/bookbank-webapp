using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookBank.Migrations
{
    /// <inheritdoc />
    public partial class AddProductToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "CoverTypes",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Productid = table.Column<int>(name: "Product_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTitle = table.Column<string>(name: "Product_Title", type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(name: "Product_Description", type: "nvarchar(max)", nullable: false),
                    ProductISBN = table.Column<string>(name: "Product_ISBN", type: "nvarchar(max)", nullable: false),
                    ProductAuthor = table.Column<string>(name: "Product_Author", type: "nvarchar(max)", nullable: false),
                    ProductListPrice = table.Column<double>(name: "Product_ListPrice", type: "float", nullable: false),
                    ProductPrice = table.Column<double>(name: "Product_Price", type: "float", nullable: false),
                    ProductPrice50 = table.Column<double>(name: "Product_Price50", type: "float", nullable: false),
                    ProductPrice100 = table.Column<double>(name: "Product_Price100", type: "float", nullable: false),
                    ProductImageUrl = table.Column<string>(name: "Product_ImageUrl", type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CoverTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Productid);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_CoverTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CoverTypeId",
                table: "Products",
                column: "CoverTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CoverTypes",
                newName: "id");
        }
    }
}
