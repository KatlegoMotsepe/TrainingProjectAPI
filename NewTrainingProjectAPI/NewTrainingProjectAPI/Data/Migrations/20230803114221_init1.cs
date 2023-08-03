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
                name: "FK_SessionDetails_Users_UerId",
                table: "SessionDetails");

            migrationBuilder.DropIndex(
                name: "IX_SessionDetails_UerId",
                table: "SessionDetails");

            migrationBuilder.DropColumn(
                name: "UerId",
                table: "SessionDetails");

            migrationBuilder.CreateIndex(
                name: "IX_SessionDetails_UserId",
                table: "SessionDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionDetails_Users_UserId",
                table: "SessionDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionDetails_Users_UserId",
                table: "SessionDetails");

            migrationBuilder.DropIndex(
                name: "IX_SessionDetails_UserId",
                table: "SessionDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "UerId",
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
        }
    }
}
