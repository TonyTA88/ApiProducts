using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiProducts.Migrations
{
    public partial class links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "links",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "links",
                table: "Products");
        }
    }
}
