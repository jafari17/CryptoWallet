using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "optionPositionHistory",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "delta",
                table: "optionPositionHistory",
                newName: "Delta");

            migrationBuilder.RenameColumn(
                name: "average_price",
                table: "optionPositionHistory",
                newName: "Vega");

            migrationBuilder.AddColumn<double>(
                name: "AveragePrice",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AveragePriceUsd",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "optionPositionHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "FloatingProfitLoss",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FloatingProfitLossUsd",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Gamma",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "IndexPrice",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InitialMargin",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Kind",
                table: "optionPositionHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MaintenanceMargin",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RealizedProfitLoss",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SettlementPrice",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Theta",
                table: "optionPositionHistory",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AveragePrice",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "AveragePriceUsd",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "FloatingProfitLoss",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "FloatingProfitLossUsd",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "Gamma",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "IndexPrice",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "InitialMargin",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "Kind",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "MaintenanceMargin",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "RealizedProfitLoss",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "SettlementPrice",
                table: "optionPositionHistory");

            migrationBuilder.DropColumn(
                name: "Theta",
                table: "optionPositionHistory");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "optionPositionHistory",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Delta",
                table: "optionPositionHistory",
                newName: "delta");

            migrationBuilder.RenameColumn(
                name: "Vega",
                table: "optionPositionHistory",
                newName: "average_price");
        }
    }
}
