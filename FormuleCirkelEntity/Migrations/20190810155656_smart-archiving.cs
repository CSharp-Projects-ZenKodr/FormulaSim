﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FormuleCirkelEntity.Migrations
{
    public partial class smartarchiving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tracks_Archived",
                table: "Tracks",
                column: "Archived");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Archived",
                table: "Teams",
                column: "Archived");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_Archived",
                table: "Engines",
                column: "Archived");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_Archived",
                table: "Drivers",
                column: "Archived");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tracks_Archived",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Teams_Archived",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Engines_Archived",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_Archived",
                table: "Drivers");
        }
    }
}
