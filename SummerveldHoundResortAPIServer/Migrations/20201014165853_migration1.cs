using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SummerveldHoundResortAPIServer.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doggo",
                columns: table => new
                {
                    DoggoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoProfilePic = table.Column<string>(nullable: true),
                    DoggoDescription = table.Column<string>(nullable: true),
                    DoggoNickname = table.Column<string>(nullable: true),
                    DoggoDateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doggo", x => x.DoggoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doggo");
        }
    }
}
