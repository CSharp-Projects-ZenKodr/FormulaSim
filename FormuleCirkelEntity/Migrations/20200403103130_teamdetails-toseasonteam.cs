﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FormuleCirkelEntity.Migrations
{
    public partial class teamdetailstoseasonteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accent",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Accent",
                table: "SeasonTeams",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "SeasonTeams",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SeasonTeams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accent",
                table: "SeasonTeams");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "SeasonTeams");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SeasonTeams");

            migrationBuilder.AddColumn<string>(
                name: "Accent",
                table: "Teams",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Teams",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Teams",
                nullable: true);
        }
    }
}