using Microsoft.EntityFrameworkCore.Migrations;

namespace DragonShop.Infrastructure.Persitence.Migrations
{
    public partial class AddDragonExpertOpinion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DragonExpertOpinion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DragonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DragonExpertOpinion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DragonExpertOpinion_Dragons_DragonId",
                        column: x => x.DragonId,
                        principalTable: "Dragons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DragonExpertOpinion_DragonId",
                table: "DragonExpertOpinion",
                column: "DragonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DragonExpertOpinion");
        }
    }
}
