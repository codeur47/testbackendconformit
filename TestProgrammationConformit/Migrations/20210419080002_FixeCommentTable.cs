using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProgrammationConformit.Migrations
{
    public partial class FixeCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Comment",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Comment",
                newName: "Title");
        }
    }
}
