using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACForms.Registration.Migrations
{
    public partial class InitializeRegistrationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "registration");

            migrationBuilder.CreateTable(
                name: "Providers",
                schema: "registration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormEntryId = table.Column<Guid>(nullable: false),
                    Processed = table.Column<bool>(nullable: false),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    ProcessedDate = table.Column<DateTime>(nullable: true),
                    PDFPath = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    Username = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    MiddleInitial = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Position = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ProviderNPI = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    ProviderTaxId = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    ProviderPhysician = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ProviderCompany = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ProviderPhone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ProviderAddress1 = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ProviderAddress2 = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ProviderCity = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ProviderState = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ProviderZip = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    AccessNeeds = table.Column<string>(nullable: true),
                    AccessReason = table.Column<string>(nullable: true),
                    AccessComments = table.Column<string>(nullable: true),
                    NeedsECPA = table.Column<bool>(nullable: false),
                    NeedsEE = table.Column<bool>(nullable: false),
                    NeedsQPP = table.Column<bool>(nullable: false),
                    NeedsFTP = table.Column<bool>(nullable: false),
                    IPAddresses = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Providers",
                schema: "registration");
        }
    }
}
