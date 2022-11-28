using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackAPI.Migrations
{
    /// <inheritdoc />
    public partial class Departmentandemployeetablemodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReportingManager",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportingManager",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ReportingManager",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportingManager",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
