﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FormuleCirkelEntity.Migrations
{
    public partial class removestability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stability",
                table: "SeasonTeams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stability",
                table: "SeasonTeams",
                nullable: false,
                defaultValue: 0);
        }
    }
}