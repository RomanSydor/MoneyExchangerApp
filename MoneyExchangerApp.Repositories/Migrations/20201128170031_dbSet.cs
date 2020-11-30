using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyExchangerApp.Repositories.Migrations
{
    public partial class dbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCurrencyId = table.Column<int>(type: "int", nullable: false),
                    FromAmount = table.Column<int>(type: "int", nullable: false),
                    ToCurrencyId = table.Column<int>(type: "int", nullable: false),
                    ToAmount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeEntities_CurrencyEntities_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "CurrencyEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeEntities_CurrencyId",
                table: "ExchangeEntities",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeEntities");

            migrationBuilder.DropTable(
                name: "CurrencyEntities");
        }
    }
}
