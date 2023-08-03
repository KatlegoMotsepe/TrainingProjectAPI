using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewTrainingProjectAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionStats_Entries_EntriesId",
                table: "SessionStats");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.RenameColumn(
                name: "EntriesId",
                table: "SessionStats",
                newName: "SessionDetailsID");

            migrationBuilder.RenameIndex(
                name: "IX_SessionStats_EntriesId",
                table: "SessionStats",
                newName: "IX_SessionStats_SessionDetailsID");

            migrationBuilder.AddColumn<Guid>(
                name: "UerId",
                table: "SessionDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SessionDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SessionDetails_UerId",
                table: "SessionDetails",
                column: "UerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionDetails_Users_UerId",
                table: "SessionDetails",
                column: "UerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionStats_SessionDetails_SessionDetailsID",
                table: "SessionStats",
                column: "SessionDetailsID",
                principalTable: "SessionDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionDetails_Users_UerId",
                table: "SessionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionStats_SessionDetails_SessionDetailsID",
                table: "SessionStats");

            migrationBuilder.DropIndex(
                name: "IX_SessionDetails_UerId",
                table: "SessionDetails");

            migrationBuilder.DropColumn(
                name: "UerId",
                table: "SessionDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SessionDetails");

            migrationBuilder.RenameColumn(
                name: "SessionDetailsID",
                table: "SessionStats",
                newName: "EntriesId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionStats_SessionDetailsID",
                table: "SessionStats",
                newName: "IX_SessionStats_EntriesId");

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_SessionDetails_SessionDetailsId",
                        column: x => x.SessionDetailsId,
                        principalTable: "SessionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_Users_UerId",
                        column: x => x.UerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_SessionDetailsId",
                table: "Entries",
                column: "SessionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UerId",
                table: "Entries",
                column: "UerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionStats_Entries_EntriesId",
                table: "SessionStats",
                column: "EntriesId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
