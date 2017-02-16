using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnD.Data.Migrations
{
    public partial class DnD1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "DnD_Info");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DnD_Info");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "DnD_Info");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "DnD_Info");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "DnD_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gold",
                table: "DnD_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "DnD_Info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DnD_Info",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "DnD_Info");

            migrationBuilder.DropColumn(
                name: "Gold",
                table: "DnD_Info");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "DnD_Info");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DnD_Info");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "DnD_Info",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "DnD_Info",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "DnD_Info",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "DnD_Info",
                nullable: true);
        }
    }
}
