using Microsoft.EntityFrameworkCore.Migrations;

namespace SummerveldHoundResortAPIServer.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoggoName",
                table: "doggo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoggoName",
                table: "doggo");
        }
    }
}
