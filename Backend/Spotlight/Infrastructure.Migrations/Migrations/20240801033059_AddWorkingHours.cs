using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkingHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "working_hours",
                columns: table => new
                {
                    working_hours_id = table.Column<int>(type: "int", nullable: false, comment: "Id режима работы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day_of_week = table.Column<int>(type: "int", nullable: false, comment: "День недели"),
                    opening_time = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Время открытия"),
                    closing_time = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Время закрытия"),
                    theater_id = table.Column<int>(type: "int", nullable: false, comment: "Id театра")
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "working_hours");
        }
    }
}
