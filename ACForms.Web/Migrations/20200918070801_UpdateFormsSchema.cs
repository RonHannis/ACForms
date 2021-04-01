using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Web.Migrations
{
    public partial class UpdateFormsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrefillType",
                schema: "acforms",
                table: "Forms",
                type: "NVARCHAR(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccessLevel",
                schema: "acforms",
                table: "Forms",
                type: "NVARCHAR(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FormSchema",
                schema: "acforms",
                table: "Forms",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "acforms",
                table: "Entries",
                type: "NVARCHAR(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormSchema",
                schema: "acforms",
                table: "Forms");

            migrationBuilder.AlterColumn<string>(
                name: "PrefillType",
                schema: "acforms",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)");

            migrationBuilder.AlterColumn<string>(
                name: "AccessLevel",
                schema: "acforms",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "acforms",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)");
        }
    }
}
