using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Web.Migrations
{
    public partial class PreFillProcessors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrefillType",
                schema: "acforms",
                table: "Forms");

            migrationBuilder.CreateTable(
                name: "PreFillProcessors",
                schema: "acforms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormKey = table.Column<string>(maxLength: 100, nullable: true),
                    ProcessorType = table.Column<string>(nullable: false),
                    ConversionSpec = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreFillProcessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreFillProcessors_Forms_FormKey",
                        column: x => x.FormKey,
                        principalSchema: "acforms",
                        principalTable: "Forms",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreFillProcessors_FormKey",
                schema: "acforms",
                table: "PreFillProcessors",
                column: "FormKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreFillProcessors",
                schema: "acforms");

            migrationBuilder.AddColumn<string>(
                name: "PrefillType",
                schema: "acforms",
                table: "Forms",
                type: "NVARCHAR(30)",
                nullable: false,
                defaultValue: "");
        }
    }
}
