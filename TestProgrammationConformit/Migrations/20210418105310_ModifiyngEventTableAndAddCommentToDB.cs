using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TestProgrammationConformit.Migrations
{
    public partial class ModifiyngEventTableAndAddCommentToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventItems",
                table: "EventItems");

            migrationBuilder.DropColumn(
                name: "CommandLine",
                table: "EventItems");

            migrationBuilder.DropColumn(
                name: "HowTo",
                table: "EventItems");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "EventItems");

            migrationBuilder.RenameTable(
                name: "EventItems",
                newName: "Event");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Event",
                newName: "EventId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Event",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventOwner",
                table: "Event",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Event",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventFK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Event_EventFK",
                        column: x => x.EventFK,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_EventFK",
                table: "Comment",
                column: "EventFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventOwner",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "EventItems");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventItems",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CommandLine",
                table: "EventItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HowTo",
                table: "EventItems",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "EventItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventItems",
                table: "EventItems",
                column: "Id");
        }
    }
}
