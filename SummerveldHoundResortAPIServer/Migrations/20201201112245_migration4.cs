using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SummerveldHoundResortAPIServer.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LifeEventDate",
                table: "lifeEvent",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateTable(
                name: "lifeEventViewModel",
                columns: table => new
                {
                    LifeEventId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoId = table.Column<int>(nullable: false),
                    IconId = table.Column<int>(nullable: false),
                    LifeEventName = table.Column<string>(nullable: true),
                    LifeEventDate = table.Column<DateTime>(nullable: false),
                    LifeEventDateCreated = table.Column<DateTime>(nullable: false),
                    DoggoName = table.Column<string>(nullable: true),
                    DoggoProfilePic = table.Column<string>(nullable: true),
                    DoggoDescription = table.Column<string>(nullable: true),
                    DoggoNickname = table.Column<string>(nullable: true),
                    DoggoDateCreated = table.Column<DateTime>(nullable: false),
                    IconSrcUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lifeEventViewModel", x => x.LifeEventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lifeEventViewModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LifeEventDate",
                table: "lifeEvent",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
