using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Web.Migrations
{
    public partial class FormAttachments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_FormEntry_FormEntryId1",
                schema: "acforms",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_FormEntryId1",
                schema: "acforms",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "FormEntryId1",
                schema: "acforms",
                table: "Attachments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FormEntryId1",
                schema: "acforms",
                table: "Attachments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_FormEntryId1",
                schema: "acforms",
                table: "Attachments",
                column: "FormEntryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_FormEntry_FormEntryId1",
                schema: "acforms",
                table: "Attachments",
                column: "FormEntryId1",
                principalSchema: "acforms",
                principalTable: "FormEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
