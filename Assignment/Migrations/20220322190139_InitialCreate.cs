using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PromotionType = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyingXQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    PayingYQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    DiscountedPrice = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    PromotionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionProgram_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionProgram_Promotion_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "IMT" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "FWH" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "DNV" });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 1, "10 health check-up items", "Basic", 99.99m });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 2, "15 health check-up items", "Standard", 129.99m });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 3, "20 health check-up items", "Advanced", 149.99m });

            migrationBuilder.InsertData(
                table: "Promotion",
                columns: new[] { "Id", "BuyingXQuantity", "Description", "DiscountedPrice", "PackageId", "PayingYQuantity", "PromotionType" },
                values: new object[] { 1, 6, "Get a 6 of 4 for Basic Package", null, 1, 4, 1 });

            migrationBuilder.InsertData(
                table: "Promotion",
                columns: new[] { "Id", "BuyingXQuantity", "Description", "DiscountedPrice", "PackageId", "PayingYQuantity", "PromotionType" },
                values: new object[] { 2, 10, "Get a 10 of 5 for Standard Package", null, 2, 5, 1 });

            migrationBuilder.InsertData(
                table: "Promotion",
                columns: new[] { "Id", "BuyingXQuantity", "Description", "DiscountedPrice", "PackageId", "PayingYQuantity", "PromotionType" },
                values: new object[] { 3, null, "On Advanced Package get the price drops to $139.99", 139.99m, 3, null, 0 });

            migrationBuilder.InsertData(
                table: "PromotionProgram",
                columns: new[] { "Id", "CustomerId", "PromotionId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "PromotionProgram",
                columns: new[] { "Id", "CustomerId", "PromotionId" },
                values: new object[] { 2, 3, 3 });

            migrationBuilder.InsertData(
                table: "PromotionProgram",
                columns: new[] { "Id", "CustomerId", "PromotionId" },
                values: new object[] { 3, 4, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionProgram_CustomerId",
                table: "PromotionProgram",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionProgram_PromotionId",
                table: "PromotionProgram",
                column: "PromotionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "PromotionProgram");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Promotion");
        }
    }
}
