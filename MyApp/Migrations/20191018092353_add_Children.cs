using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApp.Migrations
{
    public partial class add_Children : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestEntityChildren",
                columns: table => new
                {
                    AppId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEntityChildren", x => new { x.AppId, x.Name });
                    table.ForeignKey(
                        name: "FK_TestEntityChildren_TestEntities_AppId_Name",
                        columns: x => new { x.AppId, x.Name },
                        principalTable: "TestEntities",
                        principalColumns: new[] { "AppId", "Name" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestEntityChildren");
        }
    }
}
