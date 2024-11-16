using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRendalAPI.Migrations
{
    /// <inheritdoc />
    public partial class kayan1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Addresses",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Addresses",
                newName: "AddressLine1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "District",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Addresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Addresses",
                newName: "Country");
        }
    }
}
