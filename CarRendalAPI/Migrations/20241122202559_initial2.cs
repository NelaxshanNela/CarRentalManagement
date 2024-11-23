using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRendalAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedeBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Brands");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CarImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedeBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ServiceRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CarImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
