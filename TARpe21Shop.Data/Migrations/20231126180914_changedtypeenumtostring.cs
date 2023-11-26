﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe21Shop.Data.Migrations
{
    public partial class changedtypeenumtostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstateType",
                table: "RealEstates");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "RealEstates");

            migrationBuilder.AddColumn<int>(
                name: "EstateType",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
