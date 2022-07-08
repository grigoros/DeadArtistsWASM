using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeadArtistsWASM.Server.Migrations
{
    public partial class ServerRestart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Books", "books" },
                    { 2, "Movies", "movies" },
                    { 3, "Music", "music" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "Hardback" },
                    { 4, "Blue-ray" },
                    { 5, "VHS" },
                    { 6, "CD" },
                    { 7, "Vinyl" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Anna Karenina (Russian: «Анна Каренина», IPA: [ˈanːə kɐˈrʲenʲɪnə])[1] is a novel by the Russian author Leo Tolstoy, first published in book form in 1878. Widely considered to be one of the greatest works of literature ever written,[2] Tolstoy himself called it his first true novel. It was initially released in serial installments from 1875 to 1877, all but the last part appearing in the periodical The Russian Messenger.[3]", false, "https://images-na.ssl-images-amazon.com/images/I/41MCjKLqN9L._SY291_BO1,204,203,200_QL40_FMwebp_.jpg", "Anna Karenina" },
                    { 2, 1, "The Brothers Karamazov (Russian: Братья Карамазовы, Brat'ya Karamazovy, pronounced [ˈbratʲjə kərɐˈmazəvɨ]), also translated as The Karamazov Brothers, is the last novel by Russian author Fyodor Dostoevsky. Dostoevsky spent nearly two years writing The Brothers Karamazov, which was published as a serial in The Russian Messenger from January 1879 to November 1880. Dostoevsky died less than four months after its publication.", false, "https://images-na.ssl-images-amazon.com/images/I/41HLWWP2ZWL._SY291_BO1,204,203,200_QL40_FMwebp_.jpg", "The Brothers Karamazov" },
                    { 3, 1, "The Lord of the Rings is an epic[1] high-fantasy novel[a] by English author and scholar J. R. R. Tolkien. Set in Middle-earth, intended to be Earth at some distant time in the past, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.", true, "https://m.media-amazon.com/images/I/51bJhsl5VmL._SY346_.jpg", "The Lord of the Rings" },
                    { 4, 2, "It's a Wonderful Life is a 1946 American Christmas fantasy drama film produced and directed by Frank Capra, based on the short story and booklet The Greatest Gift, which Philip Van Doren Stern self-published in 1943 and is in turn loosely based on the 1843 Charles Dickens novella A Christmas Carol.[4] The film stars James Stewart as George Bailey, a man who has given up his personal dreams, in order to help others in his community, and whose thoughts of suicide on Christmas Eve brings about the intervention of his guardian angel, Clarence Odbody (Henry Travers).", false, "https://m.media-amazon.com/images/I/71OzD09EmQL._SY445_.jpg", "It's a Wonderful Life" },
                    { 5, 2, "Casablanca is a 1942 American romantic drama film directed by Michael Curtiz, and starring Humphrey Bogart, Ingrid Bergman, and Paul Henreid. Filmed and set during World War II, it focuses on an American expatriate (Bogart) who must choose between his love for a woman (Bergman) or helping her and her husband (Henreid), a Czech resistance leader, escape from the Vichy-controlled city of Casablanca to continue his fight against the Germans. The screenplay is based on Everybody Comes to Rick's, an unproduced stage play by Murray Burnett and Joan Alison. The supporting cast features Claude Rains, Conrad Veidt, Sydney Greenstreet, Peter Lorre, and Dooley Wilson.", false, "https://m.media-amazon.com/images/I/51k3eupDstL.jpg", "Casablanca" },
                    { 6, 2, "The Seventh Seal (Swedish: Det sjunde inseglet) is a 1957 Swedish historical fantasy film written and directed by Ingmar Bergman. Set in Sweden[3][4] during the Black Death, it tells of the journey of a medieval knight (Max von Sydow) and a game of chess he plays with the personification of Death (Bengt Ekerot), who has come to take his life.", true, "https://m.media-amazon.com/images/I/71eJuo8oTGL._SY445_.jpg", "The Seventh Seal" },
                    { 7, 3, "Roman Candle is the debut studio album by American singer-songwriter Elliott Smith. It was recorded in late 1993 and released on July 14, 1994 by record label Cavity Search.", true, "https://images-na.ssl-images-amazon.com/images/I/51Es-Y9Fv7L._SX300_SY300_QL70_FMwebp_.jpg", "Roman Candle" },
                    { 8, 3, "All Things Must Pass is the third studio album by English rock musician George Harrison. Released as a triple album in November 1970, it was Harrison's first solo work after the break-up of the Beatles in April that year.", false, "https://m.media-amazon.com/images/I/81yhPJT66vL._SY355_.jpg", "All Things Must Pass" },
                    { 9, 3, "Grace is the only studio album by American singer-songwriter Jeff Buckley, released on August 23, 1994, by Columbia Records. The album had poor sales and received mixed reviews at the time of its release.[4] However, in recent years it has dramatically risen in critical reputation. An extended version of the album (subtitled 'Legacy Edition'), celebrating its tenth anniversary, was released on August 23, 2004, and peaked at number 44 in the UK.", false, "https://m.media-amazon.com/images/I/81b3GHV5YAL._SY355_.jpg", "Grace" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 2, 14.99m, 10.99m },
                    { 1, 3, 0m, 22.99m },
                    { 2, 2, 13.99m, 9.99m },
                    { 2, 3, 0m, 20.99m },
                    { 3, 2, 13.99m, 10.99m },
                    { 3, 3, 0m, 19.99m },
                    { 4, 4, 14.99m, 8.99m },
                    { 4, 5, 0m, 13.99m },
                    { 5, 4, 14.99m, 10.99m },
                    { 5, 5, 0m, 12.99m },
                    { 6, 4, 12.99m, 9.99m },
                    { 6, 5, 13.99m, 10.99m },
                    { 7, 6, 13.99m, 9.99m },
                    { 7, 7, 0m, 15.99m },
                    { 8, 6, 11.99m, 8.99m },
                    { 8, 7, 0m, 9.99m },
                    { 9, 6, 16.99m, 12.99m },
                    { 9, 7, 13.99m, 11.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
