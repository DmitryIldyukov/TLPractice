using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false, comment: "Id автора")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false, comment: "ФИО автора"),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата рождения")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "theaters",
                columns: table => new
                {
                    theater_id = table.Column<int>(type: "int", nullable: false, comment: "Id театра")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Название"),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Адрес"),
                    first_opening_date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата первого открытия"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Описание"),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Номер для связи")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theaters", x => x.theater_id);
                });

            migrationBuilder.CreateTable(
                name: "compositions",
                columns: table => new
                {
                    composition_id = table.Column<int>(type: "int", nullable: false, comment: "Id композиции")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false, comment: "Название композиции"),
                    heroes_information = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Информация о героях произведения"),
                    short_description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Краткое описание"),
                    author_id = table.Column<int>(type: "int", nullable: false, comment: "Id автора")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compositions", x => x.composition_id);
                    table.ForeignKey(
                        name: "FK_compositions_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "plays",
                columns: table => new
                {
                    play_id = table.Column<int>(type: "int", nullable: false, comment: "Id представления")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Название"),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата начала"),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Дата завершения"),
                    ticket_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Стоимость билета"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Описание"),
                    theater_id = table.Column<int>(type: "int", nullable: false, comment: "Id театра"),
                    composition_id = table.Column<int>(type: "int", nullable: false, comment: "Id композиции")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plays", x => x.play_id);
                    table.ForeignKey(
                        name: "FK_plays_compositions_composition_id",
                        column: x => x.composition_id,
                        principalTable: "compositions",
                        principalColumn: "composition_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plays_theaters_theater_id",
                        column: x => x.theater_id,
                        principalTable: "theaters",
                        principalColumn: "theater_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compositions_author_id",
                table: "compositions",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_plays_composition_id",
                table: "plays",
                column: "composition_id");

            migrationBuilder.CreateIndex(
                name: "IX_plays_theater_id",
                table: "plays",
                column: "theater_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plays");

            migrationBuilder.DropTable(
                name: "compositions");

            migrationBuilder.DropTable(
                name: "theaters");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
