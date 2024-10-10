using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceptionRegistrationWeb.Migrations
{
    public partial class modelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemRegistrationInformation",
                table: "tblShowroomCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemRegistrationInformation",
                table: "tblShowroomCustomers");
        }
    }
}
