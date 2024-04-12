using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "optionPositionHistory",
                columns: table => new
                {
                    OptionPositionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InstrumentName = table.Column<string>(type: "TEXT", nullable: false),
                    size = table.Column<double>(type: "REAL", nullable: false),
                    average_price = table.Column<double>(type: "REAL", nullable: false),
                    MarkPrice = table.Column<double>(type: "REAL", nullable: false),
                    TotalProfitLoss = table.Column<double>(type: "REAL", nullable: false),
                    delta = table.Column<double>(type: "REAL", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResponseOut = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_optionPositionHistory", x => x.OptionPositionId);
                });

            migrationBuilder.CreateTable(
                name: "OptionPositions",
                columns: table => new
                {
                    OptionPositionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InstrumentName = table.Column<string>(type: "TEXT", nullable: false),
                    size = table.Column<double>(type: "REAL", nullable: false),
                    average_price = table.Column<double>(type: "REAL", nullable: false),
                    MarkPrice = table.Column<double>(type: "REAL", nullable: false),
                    TotalProfitLoss = table.Column<double>(type: "REAL", nullable: false),
                    delta = table.Column<double>(type: "REAL", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResponseOut = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionPositions", x => x.OptionPositionId);
                });

            migrationBuilder.CreateTable(
                name: "userTests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Family = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTests", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "optionTransaction",
                columns: table => new
                {
                    TransactionLogId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OptionPositionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfitAsCashflow = table.Column<string>(type: "TEXT", nullable: false),
                    PriceCurrency = table.Column<string>(type: "TEXT", nullable: false),
                    UserRole = table.Column<string>(type: "TEXT", nullable: false),
                    TradeId = table.Column<string>(type: "TEXT", nullable: false),
                    InterestPl = table.Column<double>(type: "REAL", nullable: false),
                    Contracts = table.Column<double>(type: "REAL", nullable: false),
                    Side = table.Column<string>(type: "TEXT", nullable: false),
                    UserSeq = table.Column<long>(type: "INTEGER", nullable: false),
                    Equity = table.Column<double>(type: "REAL", nullable: false),
                    FeeBalance = table.Column<double>(type: "REAL", nullable: false),
                    InstrumentName = table.Column<string>(type: "TEXT", nullable: false),
                    OrderId = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    MarkPrice = table.Column<double>(type: "REAL", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    IndexPrice = table.Column<double>(type: "REAL", nullable: false),
                    Cashflow = table.Column<double>(type: "REAL", nullable: false),
                    Commission = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Change = table.Column<double>(type: "REAL", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<long>(type: "INTEGER", nullable: false),
                    Position = table.Column<double>(type: "REAL", nullable: false),
                    Info = table.Column<string>(type: "TEXT", nullable: false),
                    IdJson = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_optionTransaction", x => x.TransactionLogId);
                    table.ForeignKey(
                        name: "FK_optionTransaction_OptionPositions_OptionPositionId",
                        column: x => x.OptionPositionId,
                        principalTable: "OptionPositions",
                        principalColumn: "OptionPositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_optionTransaction_OptionPositionId",
                table: "optionTransaction",
                column: "OptionPositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "optionPositionHistory");

            migrationBuilder.DropTable(
                name: "optionTransaction");

            migrationBuilder.DropTable(
                name: "userTests");

            migrationBuilder.DropTable(
                name: "OptionPositions");
        }
    }
}
