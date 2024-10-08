using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brands_BranId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BranId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BranId",
                table: "Beers");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BrandId",
                table: "Beers",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brands_BrandId",
                table: "Beers",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brands_BrandId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BrandId",
                table: "Beers");

            migrationBuilder.AddColumn<int>(
                name: "BranId",
                table: "Beers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BranId",
                table: "Beers",
                column: "BranId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brands_BranId",
                table: "Beers",
                column: "BranId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
