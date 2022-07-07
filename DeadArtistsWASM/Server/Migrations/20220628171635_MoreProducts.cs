using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeadArtistsWASM.Server.Migrations
{
    public partial class MoreProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 4, 2, "It's a Wonderful Life is a 1946 American Christmas fantasy drama film produced and directed by Frank Capra, based on the short story and booklet The Greatest Gift, which Philip Van Doren Stern self-published in 1943 and is in turn loosely based on the 1843 Charles Dickens novella A Christmas Carol.[4] The film stars James Stewart as George Bailey, a man who has given up his personal dreams, in order to help others in his community, and whose thoughts of suicide on Christmas Eve brings about the intervention of his guardian angel, Clarence Odbody (Henry Travers).", "https://m.media-amazon.com/images/I/71OzD09EmQL._SY445_.jpg", 17.99m, "It's a Wonderful Life" },
                    { 5, 2, "Casablanca is a 1942 American romantic drama film directed by Michael Curtiz, and starring Humphrey Bogart, Ingrid Bergman, and Paul Henreid. Filmed and set during World War II, it focuses on an American expatriate (Bogart) who must choose between his love for a woman (Bergman) or helping her and her husband (Henreid), a Czech resistance leader, escape from the Vichy-controlled city of Casablanca to continue his fight against the Germans. The screenplay is based on Everybody Comes to Rick's, an unproduced stage play by Murray Burnett and Joan Alison. The supporting cast features Claude Rains, Conrad Veidt, Sydney Greenstreet, Peter Lorre, and Dooley Wilson.", "https://m.media-amazon.com/images/I/51k3eupDstL.jpg", 18.99m, "Casablanca" },
                    { 6, 2, "The Seventh Seal (Swedish: Det sjunde inseglet) is a 1957 Swedish historical fantasy film written and directed by Ingmar Bergman. Set in Sweden[3][4] during the Black Death, it tells of the journey of a medieval knight (Max von Sydow) and a game of chess he plays with the personification of Death (Bengt Ekerot), who has come to take his life.", "", 17.99m, "The Seventh Seal" },
                    { 7, 3, "Roman Candle is the debut studio album by American singer-songwriter Elliott Smith. It was recorded in late 1993 and released on July 14, 1994 by record label Cavity Search.", "https://images-na.ssl-images-amazon.com/images/I/51Es-Y9Fv7L._SX300_SY300_QL70_FMwebp_.jpg", 14.99m, "Roman Candle" },
                    { 8, 3, "All Things Must Pass is the third studio album by English rock musician George Harrison. Released as a triple album in November 1970, it was Harrison's first solo work after the break-up of the Beatles in April that year.", "https://m.media-amazon.com/images/I/81yhPJT66vL._SY355_.jpg", 13.99m, "All Things Must Pass" },
                    { 9, 3, "Grace is the only studio album by American singer-songwriter Jeff Buckley, released on August 23, 1994, by Columbia Records. The album had poor sales and received mixed reviews at the time of its release.[4] However, in recent years it has dramatically risen in critical reputation. An extended version of the album (subtitled 'Legacy Edition'), celebrating its tenth anniversary, was released on August 23, 2004, and peaked at number 44 in the UK.", "https://m.media-amazon.com/images/I/81b3GHV5YAL._SY355_.jpg", 12.99m, "Grace" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
