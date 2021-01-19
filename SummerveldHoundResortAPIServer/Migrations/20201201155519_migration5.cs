using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SummerveldHoundResortAPIServer.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LifeEventDate",
                table: "lifeEventViewModel",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LifeEventDate",
                table: "lifeEventViewModel",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
