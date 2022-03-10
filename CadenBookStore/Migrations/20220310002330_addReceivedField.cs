using Microsoft.EntityFrameworkCore.Migrations;

namespace CadenBookStore.Migrations
{
    public partial class addReceivedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BookReceived",
                table: "bookcarts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookReceived",
                table: "bookcarts");
        }
    }
}
