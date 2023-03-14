using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashSaver.Repositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bill",
                columns: new[] { "Id", "CreatedAt", "Description", "ExpirationDate", "LastModifiedAt", "PaidDate", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("1c71bbc2-f9fc-4988-b1c5-f51e081aad20"), new DateTime(2023, 3, 14, 0, 6, 9, 257, DateTimeKind.Utc).AddTicks(9205), "Descrição 4", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100.00m, "Teste 4" },
                    { new Guid("1f8686b6-0cf6-44c3-a35e-c866f656f63f"), new DateTime(2023, 3, 14, 0, 6, 9, 257, DateTimeKind.Utc).AddTicks(9202), "Descrição 2", new DateTime(2023, 5, 13, 21, 6, 9, 257, DateTimeKind.Local).AddTicks(9189), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 13, 21, 6, 9, 257, DateTimeKind.Local).AddTicks(9180), 100.00m, "Teste 2" },
                    { new Guid("42ae4de0-1b65-42e8-b045-9d603891ec92"), new DateTime(2023, 3, 14, 0, 6, 9, 257, DateTimeKind.Utc).AddTicks(9177), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100.00m, "Teste 1" },
                    { new Guid("6ad9e8d5-e2af-42db-a507-85ae367d64e5"), new DateTime(2023, 3, 14, 0, 6, 9, 257, DateTimeKind.Utc).AddTicks(9204), "Descrição 3", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 13, 21, 6, 9, 257, DateTimeKind.Local).AddTicks(9202), 100.00m, "Teste 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");
        }
    }
}
