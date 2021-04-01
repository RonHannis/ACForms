using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.UiPath.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "uipath");

            migrationBuilder.CreateTable(
                name: "Submissions",
                schema: "uipath",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormEntryId = table.Column<Guid>(nullable: false),
                    Processed = table.Column<bool>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    ProcessedDate = table.Column<DateTime>(nullable: true),
                    MemberFirstName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    MemberLastName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    MemberDOB = table.Column<DateTime>(nullable: false),
                    DiagnosisCodes = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    CPTCodes = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    NPIReferTo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    NPIReferFrom = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    PDFPath = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submissions",
                schema: "uipath");
        }
    }
}
