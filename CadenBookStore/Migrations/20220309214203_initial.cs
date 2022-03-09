using Microsoft.EntityFrameworkCore.Migrations;

namespace CadenBookStore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookcarts",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookcarts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Publisher = table.Column<string>(nullable: false),
                    Isbn = table.Column<string>(nullable: false),
                    Classification = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    PageCount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "BasketLineItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    BookCartCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLineItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_bookcarts_BookCartCartId",
                        column: x => x.BookCartCartId,
                        principalTable: "bookcarts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_BookCartCartId",
                table: "BasketLineItem",
                column: "BookCartCartId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_BookId",
                table: "BasketLineItem",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketLineItem");

            migrationBuilder.DropTable(
                name: "bookcarts");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
