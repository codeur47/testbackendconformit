using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProgrammationConformit.Migrations
{
    public partial class ChangeRelationalMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Event_EventFK",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "EventFK",
                table: "Comment",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_EventFK",
                table: "Comment",
                newName: "IX_Comment_EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Event_EventId",
                table: "Comment",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Event_EventId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Comment",
                newName: "EventFK");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_EventId",
                table: "Comment",
                newName: "IX_Comment_EventFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Event_EventFK",
                table: "Comment",
                column: "EventFK",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
