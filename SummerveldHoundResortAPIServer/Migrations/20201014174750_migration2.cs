using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SummerveldHoundResortAPIServer.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doggoAlbum",
                columns: table => new
                {
                    DoggoAlbumId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoId = table.Column<int>(nullable: false),
                    DoggoAlbumName = table.Column<string>(nullable: true),
                    DoggoAlbumDateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doggoAlbum", x => x.DoggoAlbumId);
                    table.ForeignKey(
                        name: "FK_doggoAlbum_doggo_DoggoId",
                        column: x => x.DoggoId,
                        principalTable: "doggo",
                        principalColumn: "DoggoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doggoType",
                columns: table => new
                {
                    DoggoTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoId = table.Column<int>(nullable: false),
                    DoggoTypeStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doggoType", x => x.DoggoTypeId);
                    table.ForeignKey(
                        name: "FK_doggoType_doggo_DoggoId",
                        column: x => x.DoggoId,
                        principalTable: "doggo",
                        principalColumn: "DoggoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "icon",
                columns: table => new
                {
                    IconId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IconSrcUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_icon", x => x.IconId);
                });

            migrationBuilder.CreateTable(
                name: "intro",
                columns: table => new
                {
                    IntroId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoId = table.Column<int>(nullable: false),
                    IntroDateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intro", x => x.IntroId);
                    table.ForeignKey(
                        name: "FK_intro_doggo_DoggoId",
                        column: x => x.DoggoId,
                        principalTable: "doggo",
                        principalColumn: "DoggoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "virtualAdoption",
                columns: table => new
                {
                    VirtualAdoptionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoId = table.Column<int>(nullable: false),
                    IsAdopted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_virtualAdoption", x => x.VirtualAdoptionId);
                    table.ForeignKey(
                        name: "FK_virtualAdoption_doggo_DoggoId",
                        column: x => x.DoggoId,
                        principalTable: "doggo",
                        principalColumn: "DoggoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doggoContent",
                columns: table => new
                {
                    DoggoContentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoAlbumId = table.Column<int>(nullable: false),
                    DoggoContentDateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doggoContent", x => x.DoggoContentId);
                    table.ForeignKey(
                        name: "FK_doggoContent_doggoAlbum_DoggoAlbumId",
                        column: x => x.DoggoAlbumId,
                        principalTable: "doggoAlbum",
                        principalColumn: "DoggoAlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doggoFriend",
                columns: table => new
                {
                    DoggoFriendId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doggoFriend", x => x.DoggoFriendId);
                    table.ForeignKey(
                        name: "FK_doggoFriend_doggoType_DoggoTypeId",
                        column: x => x.DoggoTypeId,
                        principalTable: "doggoType",
                        principalColumn: "DoggoTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lifeEvent",
                columns: table => new
                {
                    LifeEventId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoId = table.Column<int>(nullable: false),
                    IconId = table.Column<int>(nullable: false),
                    LifeEventName = table.Column<string>(nullable: true),
                    LifeEventDate = table.Column<DateTime>(nullable: false),
                    LifeEventDateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lifeEvent", x => x.LifeEventId);
                    table.ForeignKey(
                        name: "FK_lifeEvent_doggo_DoggoId",
                        column: x => x.DoggoId,
                        principalTable: "doggo",
                        principalColumn: "DoggoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lifeEvent_icon_IconId",
                        column: x => x.IconId,
                        principalTable: "icon",
                        principalColumn: "IconId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adopted",
                columns: table => new
                {
                    AdoptedId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VirtualAdoptionId = table.Column<int>(nullable: false),
                    AdoptedDate = table.Column<DateTime>(nullable: false),
                    Pawrents = table.Column<string>(nullable: true),
                    AdoptedDateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adopted", x => x.AdoptedId);
                    table.ForeignKey(
                        name: "FK_adopted_virtualAdoption_VirtualAdoptionId",
                        column: x => x.VirtualAdoptionId,
                        principalTable: "virtualAdoption",
                        principalColumn: "VirtualAdoptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doggoPhoto",
                columns: table => new
                {
                    DoggoPhotoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoContentId = table.Column<int>(nullable: false),
                    DoggoPhotoUrl = table.Column<string>(nullable: true),
                    DoggoPhotoDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doggoPhoto", x => x.DoggoPhotoId);
                    table.ForeignKey(
                        name: "FK_doggoPhoto_doggoContent_DoggoContentId",
                        column: x => x.DoggoContentId,
                        principalTable: "doggoContent",
                        principalColumn: "DoggoContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doggoVideo",
                columns: table => new
                {
                    DoggoVideoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoggoContentId = table.Column<int>(nullable: false),
                    DoggoVideoUrl = table.Column<string>(nullable: true),
                    DoggoVideoDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doggoVideo", x => x.DoggoVideoId);
                    table.ForeignKey(
                        name: "FK_doggoVideo_doggoContent_DoggoContentId",
                        column: x => x.DoggoContentId,
                        principalTable: "doggoContent",
                        principalColumn: "DoggoContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adopted_VirtualAdoptionId",
                table: "adopted",
                column: "VirtualAdoptionId");

            migrationBuilder.CreateIndex(
                name: "IX_doggoAlbum_DoggoId",
                table: "doggoAlbum",
                column: "DoggoId");

            migrationBuilder.CreateIndex(
                name: "IX_doggoContent_DoggoAlbumId",
                table: "doggoContent",
                column: "DoggoAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_doggoFriend_DoggoTypeId",
                table: "doggoFriend",
                column: "DoggoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_doggoPhoto_DoggoContentId",
                table: "doggoPhoto",
                column: "DoggoContentId");

            migrationBuilder.CreateIndex(
                name: "IX_doggoType_DoggoId",
                table: "doggoType",
                column: "DoggoId");

            migrationBuilder.CreateIndex(
                name: "IX_doggoVideo_DoggoContentId",
                table: "doggoVideo",
                column: "DoggoContentId");

            migrationBuilder.CreateIndex(
                name: "IX_intro_DoggoId",
                table: "intro",
                column: "DoggoId");

            migrationBuilder.CreateIndex(
                name: "IX_lifeEvent_DoggoId",
                table: "lifeEvent",
                column: "DoggoId");

            migrationBuilder.CreateIndex(
                name: "IX_lifeEvent_IconId",
                table: "lifeEvent",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_virtualAdoption_DoggoId",
                table: "virtualAdoption",
                column: "DoggoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adopted");

            migrationBuilder.DropTable(
                name: "doggoFriend");

            migrationBuilder.DropTable(
                name: "doggoPhoto");

            migrationBuilder.DropTable(
                name: "doggoVideo");

            migrationBuilder.DropTable(
                name: "intro");

            migrationBuilder.DropTable(
                name: "lifeEvent");

            migrationBuilder.DropTable(
                name: "virtualAdoption");

            migrationBuilder.DropTable(
                name: "doggoType");

            migrationBuilder.DropTable(
                name: "doggoContent");

            migrationBuilder.DropTable(
                name: "icon");

            migrationBuilder.DropTable(
                name: "doggoAlbum");
        }
    }
}
