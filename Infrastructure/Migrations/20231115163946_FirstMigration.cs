using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgedTransactionSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Rule identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowRange = table.Column<int>(type: "int", nullable: false, comment: "The min value of days to apply the rule."),
                    HighRange = table.Column<int>(type: "int", nullable: true, comment: "The max value of days to apply the rule."),
                    TransferStatusId = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "The transfer status to be applied."),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The UTC date when the rule was created."),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The UTC date when the rule was updated.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgedTransactionSettings", x => x.Id);
                },
                comment: "Stores the rules to grow old the transactions automatically");

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "The transaction's identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The UTC Date the transaction was created at."),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false, comment: "The Transaction's amount."),
                    TransferStatusId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Status of the transaction."),
                    TransactionNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "Unique transaction number created by the system.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                },
                comment: "Stores Information related with Transactions.");

            migrationBuilder.CreateTable(
                name: "TransactionStatusChange",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "History entry identifier.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false, comment: "Transaction the history entry belongs to."),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the change."),
                    StatusBeforeId = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Transfer status before the change."),
                    StatusAfterId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Current transfer status.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStatusChange", x => x.Id);
                },
                comment: "Stores Transaction Status Changes History.");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionNumber",
                table: "Transaction",
                column: "TransactionNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgedTransactionSettings");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionStatusChange");
        }
    }
}
