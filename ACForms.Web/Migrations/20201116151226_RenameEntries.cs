using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Web.Migrations
{
    public partial class RenameEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_FormEntry_EntryId",
                schema: "acforms",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_FormEntry_Forms_FormKey",
                schema: "acforms",
                table: "FormEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormEntry",
                schema: "acforms",
                table: "FormEntry");

            migrationBuilder.RenameTable(
                name: "FormEntry",
                schema: "acforms",
                newName: "Entries",
                newSchema: "acforms");

            migrationBuilder.RenameIndex(
                name: "IX_FormEntry_FormKey",
                schema: "acforms",
                table: "Entries",
                newName: "IX_Entries_FormKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entries",
                schema: "acforms",
                table: "Entries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Entries_EntryId",
                schema: "acforms",
                table: "Attachments",
                column: "EntryId",
                principalSchema: "acforms",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Forms_FormKey",
                schema: "acforms",
                table: "Entries",
                column: "FormKey",
                principalSchema: "acforms",
                principalTable: "Forms",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Entries_EntryId",
                schema: "acforms",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Forms_FormKey",
                schema: "acforms",
                table: "Entries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entries",
                schema: "acforms",
                table: "Entries");

            migrationBuilder.RenameTable(
                name: "Entries",
                schema: "acforms",
                newName: "FormEntry",
                newSchema: "acforms");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_FormKey",
                schema: "acforms",
                table: "FormEntry",
                newName: "IX_FormEntry_FormKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormEntry",
                schema: "acforms",
                table: "FormEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_FormEntry_EntryId",
                schema: "acforms",
                table: "Attachments",
                column: "EntryId",
                principalSchema: "acforms",
                principalTable: "FormEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormEntry_Forms_FormKey",
                schema: "acforms",
                table: "FormEntry",
                column: "FormKey",
                principalSchema: "acforms",
                principalTable: "Forms",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
