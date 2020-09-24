﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FormuleCirkelEntity.Migrations
{
    public partial class CountryOrigin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Tracks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Drivers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Drivers");
        }
    }
}