using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeshkoBookWeb.Data.Migrations
{
    public partial class changeNameDisplayProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplyOrder",
                table: "Categories",
                newName: "DisplayOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Categories",
                newName: "DisplyOrder");
        }
    }
}
