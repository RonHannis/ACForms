using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Web.Migrations
{
    public partial class EntryArchive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ConversionSpec",
                schema: "acforms",
                table: "FormProcessors",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormEntry",
                schema: "acforms",
                table: "FormEntry",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EntryArchive",
                schema: "acforms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    EntryId = table.Column<Guid>(nullable: false),
                    FormKey = table.Column<string>(maxLength: 100, nullable: true),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    PrefillCriteria_ProviderId = table.Column<string>(maxLength: 15, nullable: true),
                    PrefillCriteria_MemberId = table.Column<string>(maxLength: 30, nullable: true),
                    PrefillCriteria_QnxtId = table.Column<string>(maxLength: 15, nullable: true),
                    PrefillCriteria_EnrollId = table.Column<string>(maxLength: 15, nullable: true),
                    PrefillCriteria_InsuredId = table.Column<string>(maxLength: 15, nullable: true),
                    PrefillCriteria_Npi = table.Column<string>(maxLength: 10, nullable: true),
                    PrefillCriteria_EligibilityId = table.Column<long>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryArchive", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormEntry_Forms_FormKey",
                schema: "acforms",
                table: "FormEntry");

            migrationBuilder.DropTable(
                name: "EntryArchive",
                schema: "acforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormEntry",
                schema: "acforms",
                table: "FormEntry");

            migrationBuilder.DropColumn(
                name: "ConversionSpec",
                schema: "acforms",
                table: "FormProcessors");

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
                name: "FK_Entries_Forms_FormKey",
                schema: "acforms",
                table: "Entries",
                column: "FormKey",
                principalSchema: "acforms",
                principalTable: "Forms",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
