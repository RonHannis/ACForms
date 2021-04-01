using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Web.Migrations
{
    public partial class ArchiveUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileAttachments",
                schema: "acforms",
                table: "EntryArchive",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormSchema",
                schema: "acforms",
                table: "EntryArchive",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Snapshot",
                schema: "acforms",
                table: "EntryArchive",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileAttachments",
                schema: "acforms",
                table: "EntryArchive");

            migrationBuilder.DropColumn(
                name: "FormSchema",
                schema: "acforms",
                table: "EntryArchive");

            migrationBuilder.DropColumn(
                name: "Snapshot",
                schema: "acforms",
                table: "EntryArchive");
        }
    }
}
