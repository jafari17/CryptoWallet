using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDecpLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "optionTransaction",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "optionTransaction");
        }
    }
}
