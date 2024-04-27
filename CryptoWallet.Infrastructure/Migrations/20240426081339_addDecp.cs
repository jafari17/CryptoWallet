using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDecp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "OptionPositions",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "OptionPositions");
        }
    }
}
