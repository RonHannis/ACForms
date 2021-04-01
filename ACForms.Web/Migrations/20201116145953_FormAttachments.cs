using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Web.Migrations
{
    public partial class FormAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowAttachments",
                schema: "acforms",
                table: "Forms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "acforms",
                table: "Forms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireCAPTCHA",
                schema: "acforms",
                table: "Forms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "acforms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryId = table.Column<Guid>(nullable: false),
                    Filename = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: false),
                    FormEntryId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_FormEntry_EntryId",
                        column: x => x.EntryId,
                        principalSchema: "acforms",
                        principalTable: "FormEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_FormEntry_FormEntryId1",
                        column: x => x.FormEntryId1,
                        principalSchema: "acforms",
                        principalTable: "FormEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_EntryId",
                schema: "acforms",
                table: "Attachments",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_FormEntryId1",
                schema: "acforms",
                table: "Attachments",
                column: "FormEntryId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "acforms");

            migrationBuilder.DropColumn(
                name: "AllowAttachments",
                schema: "acforms",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "acforms",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "RequireCAPTCHA",
                schema: "acforms",
                table: "Forms");
        }
    }
}
