using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyExchangerApp.Repositories.Migrations
{
    public partial class dbUpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeEntities_CurrencyEntities_CurrencyId",
                table: "ExchangeEntities");

            migrationBuilder.DropTable(
                name: "CurrencyEntities");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeEntities_CurrencyId",
                table: "ExchangeEntities");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "ExchangeEntities");

            migrationBuilder.DropColumn(
                name: "FromCurrencyId",
                table: "ExchangeEntities");

            migrationBuilder.DropColumn(
                name: "ToCurrencyId",
                table: "ExchangeEntities");

            migrationBuilder.AddColumn<string>(
                name: "FromCurrency",
                table: "ExchangeEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCurrency",
                table: "ExchangeEntities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromCurrency",
                table: "ExchangeEntities");

            migrationBuilder.DropColumn(
                name: "ToCurrency",
                table: "ExchangeEntities");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "ExchangeEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCurrencyId",
                table: "ExchangeEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToCurrencyId",
                table: "ExchangeEntities",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeEntities_CurrencyId",
                table: "ExchangeEntities",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeEntities_CurrencyEntities_CurrencyId",
                table: "ExchangeEntities",
                column: "CurrencyId",
                principalTable: "CurrencyEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
