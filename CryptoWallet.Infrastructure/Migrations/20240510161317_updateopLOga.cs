using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateopLOga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "OptionPositions",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "delta",
                table: "OptionPositions",
                newName: "Delta");

            migrationBuilder.RenameColumn(
                name: "average_price",
                table: "OptionPositions",
                newName: "Vega");

            migrationBuilder.AddColumn<double>(
                name: "AveragePrice",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AveragePriceUsd",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "OptionPositions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "FloatingProfitLoss",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FloatingProfitLossUsd",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Gamma",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "IndexPrice",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InitialMargin",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Kind",
                table: "OptionPositions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MaintenanceMargin",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RealizedProfitLoss",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SettlementPrice",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Theta",
                table: "OptionPositions",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AveragePrice",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "AveragePriceUsd",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "FloatingProfitLoss",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "FloatingProfitLossUsd",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "Gamma",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "IndexPrice",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "InitialMargin",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "Kind",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "MaintenanceMargin",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "RealizedProfitLoss",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "SettlementPrice",
                table: "OptionPositions");

            migrationBuilder.DropColumn(
                name: "Theta",
                table: "OptionPositions");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "OptionPositions",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Delta",
                table: "OptionPositions",
                newName: "delta");

            migrationBuilder.RenameColumn(
                name: "Vega",
                table: "OptionPositions",
                newName: "average_price");
        }
    }
}
