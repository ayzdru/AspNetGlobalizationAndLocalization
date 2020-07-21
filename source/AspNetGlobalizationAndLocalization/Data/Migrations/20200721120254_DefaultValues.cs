using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetGlobalizationAndLocalization.Data.Migrations
{
    public partial class DefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Cultures_CultureId",
                table: "Resources");

            migrationBuilder.AlterColumn<int>(
                name: "CultureId",
                table: "Resources",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cultures",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "en" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CultureId", "Key", "Value" },
                values: new object[] { 1, 1, "Veritabanından Merhaba", "Hello From Database" });

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Cultures_CultureId",
                table: "Resources",
                column: "CultureId",
                principalTable: "Cultures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Cultures_CultureId",
                table: "Resources");

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cultures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "CultureId",
                table: "Resources",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Cultures_CultureId",
                table: "Resources",
                column: "CultureId",
                principalTable: "Cultures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
