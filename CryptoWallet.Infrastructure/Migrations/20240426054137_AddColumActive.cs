using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userTests");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "OptionPositions",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "OptionPositions");

            migrationBuilder.CreateTable(
                name: "userTests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 350, nullable: false),
                    Family = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTests", x => x.UserId);
                });
        }
    }
}
