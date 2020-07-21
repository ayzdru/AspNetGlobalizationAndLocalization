using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetGlobalizationAndLocalization.Data.Migrations
{
    public partial class BookSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "{\"tr\":\"Küçük Prens, Fransız yazar ve pilot Antoine de Saint-Exupéry tarafından yazılan ve 1943'te yayımlanan masal. Dünyanın en çok satan ve okunan kitaplarından biridir. Eserde bir çocuğun gözünden büyüklerin dünyası anlatılır.\", \"en\":\"After being stranded in a desert after a crash, a pilot comes in contact with a captivating little prince who recounts his journey from planet to planet and his search for what is most important in life.\"}", "{\"tr\":\"Küçük Prens\", \"en\":\"The Little Prince\"}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
