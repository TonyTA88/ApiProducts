using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiProducts.Migrations
{
    public partial class Aded_ProductLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    action = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    Oldprice = table.Column<decimal>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    stockquantity = table.Column<decimal>(nullable: false),
                    Oldstockquantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLog");
        }
    }
}
