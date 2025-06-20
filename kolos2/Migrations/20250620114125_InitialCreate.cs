using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolos2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CurrentWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                });

            migrationBuilder.CreateTable(
                name: "Backpack",
                columns: table => new
                {
                    IdBackpack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpack", x => x.IdBackpack);
                    table.ForeignKey(
                        name: "FK_Backpack_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpack_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTitle",
                columns: table => new
                {
                    CharacterTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTitle", x => x.CharacterTitleId);
                    table.ForeignKey(
                        name: "FK_CharacterTitle_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTitle_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[] { 1, 1, "Jan", "Kowalski", 2 });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemId", "Name", "Weight" },
                values: new object[] { 1, "xd", 1 });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "TitleId", "Name" },
                values: new object[] { 1, "tytul" });

            migrationBuilder.InsertData(
                table: "Backpack",
                columns: new[] { "IdBackpack", "Amount", "CharacterID", "ItemID" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "CharacterTitle",
                columns: new[] { "CharacterTitleId", "AcquiredAt", "CharacterId", "TitleId" },
                values: new object[] { 1, new DateTime(2025, 6, 20, 13, 41, 25, 406, DateTimeKind.Local).AddTicks(9007), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_CharacterID",
                table: "Backpack",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_ItemID",
                table: "Backpack",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTitle_CharacterId",
                table: "CharacterTitle",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTitle_TitleId",
                table: "CharacterTitle",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpack");

            migrationBuilder.DropTable(
                name: "CharacterTitle");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
