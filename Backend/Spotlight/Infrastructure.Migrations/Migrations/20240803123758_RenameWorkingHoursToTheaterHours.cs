using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameWorkingHoursToTheaterHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "working_hours");

            migrationBuilder.CreateTable(
                name: "theater_hours",
                columns: table => new
                {
                    theater_hours_id = table.Column<int>(type: "int", nullable: false, comment: "Id режима работы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day_of_week = table.Column<int>(type: "int", nullable: false, comment: "День недели"),
                    opening_time = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Время открытия"),
                    closing_time = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Время закрытия"),
                    theater_id = table.Column<int>(type: "int", nullable: false, comment: "Id театра")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theater_hours", x => x.theater_hours_id);
                    table.ForeignKey(
                        name: "FK_theater_hours_theaters_theater_id",
                        column: x => x.theater_id,
                        principalTable: "theaters",
                        principalColumn: "theater_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_theater_hours_theater_id",
                table: "theater_hours",
                column: "theater_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "theater_hours");

            migrationBuilder.CreateTable(
                name: "working_hours",
                columns: table => new
                {
                    working_hours_id = table.Column<int>(type: "int", nullable: false, comment: "Id режима работы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    theater_id = table.Column<int>(type: "int", nullable: false, comment: "Id театра"),
                    closing_time = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Время закрытия"),
                    day_of_week = table.Column<int>(type: "int", nullable: false, comment: "День недели"),
                    opening_time = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Время открытия")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_working_hours", x => x.working_hours_id);
                    table.ForeignKey(
                        name: "FK_working_hours_theaters_theater_id",
                        column: x => x.theater_id,
                        principalTable: "theaters",
                        principalColumn: "theater_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_working_hours_theater_id",
                table: "working_hours",
                column: "theater_id");
        }
    }
}
