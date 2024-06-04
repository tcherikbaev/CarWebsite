using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWebsite.Migrations
{
    public partial class ShopCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopCardItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carid = table.Column<int>(nullable: true),
                    prize = table.Column<int>(nullable: false),
                    ShopCarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCardItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopCardItem_Car_carid",
                        column: x => x.carid,
                        principalTable: "Car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCardItem_carid",
                table: "ShopCardItem",
                column: "carid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCardItem");
        }
    }
}
