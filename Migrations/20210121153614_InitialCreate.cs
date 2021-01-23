using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesVideoGameDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoGameModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameTitle = table.Column<string>(nullable: true),
                    ReleaseYear = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    CompleteCopy = table.Column<string>(nullable: true),
                    PhysicalCopy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGameModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGameModel");
        }
    }
}
