﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackAPI.Migrations
{
    /// <inheritdoc />
    public partial class Dependentmodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Relationship",
                table: "Dependents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Relationship",
                table: "Dependents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
