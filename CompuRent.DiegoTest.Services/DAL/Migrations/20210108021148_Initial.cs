using Microsoft.EntityFrameworkCore.Migrations;

namespace CompuRent.DiegoTest.Services.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "album_sets",
                columns: table => new
                {
                    AlbumSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album_sets", x => x.AlbumSetId);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientId = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "songs_sets",
                columns: table => new
                {
                    SongSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    AlbumSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs_sets", x => x.SongSetId);
                    table.ForeignKey(
                        name: "FK_songs_sets_album_sets_AlbumSetId",
                        column: x => x.AlbumSetId,
                        principalTable: "album_sets",
                        principalColumn: "AlbumSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchase_details",
                columns: table => new
                {
                    PurchaseDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<string>(maxLength: 10, nullable: false),
                    AlbumSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_details", x => x.PurchaseDetailId);
                    table.ForeignKey(
                        name: "FK_purchase_details_album_sets_AlbumSetId",
                        column: x => x.AlbumSetId,
                        principalTable: "album_sets",
                        principalColumn: "AlbumSetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchase_details_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_ClientId",
                table: "clients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_details_AlbumSetId",
                table: "purchase_details",
                column: "AlbumSetId");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_details_ClientId",
                table: "purchase_details",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_songs_sets_AlbumSetId",
                table: "songs_sets",
                column: "AlbumSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchase_details");

            migrationBuilder.DropTable(
                name: "songs_sets");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "album_sets");
        }
    }
}
