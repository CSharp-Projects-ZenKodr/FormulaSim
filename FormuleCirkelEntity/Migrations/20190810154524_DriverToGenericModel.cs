﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FormuleCirkelEntity.Migrations
{
    public partial class DriverToGenericModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "Drivers",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {migrationBuilder.RenameColumn(
                name: "Id",
                table: "Drivers",
                newName: "DriverId");
        }
    }
}
