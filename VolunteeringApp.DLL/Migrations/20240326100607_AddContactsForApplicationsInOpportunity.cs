using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunteeringApp.DLL.Migrations
{
    public partial class AddContactsForApplicationsInOpportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumberForApplications",
                table: "Opportunities",
                newName: "ContactsForApplications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactsForApplications",
                table: "Opportunities",
                newName: "PhoneNumberForApplications");
        }
    }
}
