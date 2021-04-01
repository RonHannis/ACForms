using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "acforms");

            migrationBuilder.CreateTable(
                name: "Forms",
                schema: "acforms",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    AccessLevel = table.Column<string>(nullable: false),
                    PrefillType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                schema: "acforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FormKey = table.Column<string>(maxLength: 100, nullable: true),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Forms_FormKey",
                        column: x => x.FormKey,
                        principalSchema: "acforms",
                        principalTable: "Forms",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormProcessors",
                schema: "acforms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormKey = table.Column<string>(maxLength: 100, nullable: true),
                    ProcessorType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormProcessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormProcessors_Forms_FormKey",
                        column: x => x.FormKey,
                        principalSchema: "acforms",
                        principalTable: "Forms",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_FormKey",
                schema: "acforms",
                table: "Entries",
                column: "FormKey");

            migrationBuilder.CreateIndex(
                name: "IX_FormProcessors_FormKey",
                schema: "acforms",
                table: "FormProcessors",
                column: "FormKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries",
                schema: "acforms");

            migrationBuilder.DropTable(
                name: "FormProcessors",
                schema: "acforms");

            migrationBuilder.DropTable(
                name: "Forms",
                schema: "acforms");
        }
    }
}
