using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewTrainingProjectAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PassHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionDetails_Users_UerId",
                        column: x => x.UerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    SessionDetailsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_SessionDetails_SessionDetailsID",
                        column: x => x.SessionDetailsID,
                        principalTable: "SessionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopSpeed = table.Column<double>(type: "float", nullable: false),
                    LowSpeed = table.Column<double>(type: "float", nullable: false),
                    AveSpeed = table.Column<double>(type: "float", nullable: false),
                    AvePace = table.Column<double>(type: "float", nullable: false),
                    SessionDetailsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionStats_SessionDetails_SessionDetailsID",
                        column: x => x.SessionDetailsID,
                        principalTable: "SessionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Points_SessionDetailsID",
                table: "Points",
                column: "SessionDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionDetails_UerId",
                table: "SessionDetails",
                column: "UerId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionStats_SessionDetailsID",
                table: "SessionStats",
                column: "SessionDetailsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "SessionStats");

            migrationBuilder.DropTable(
                name: "SessionDetails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
