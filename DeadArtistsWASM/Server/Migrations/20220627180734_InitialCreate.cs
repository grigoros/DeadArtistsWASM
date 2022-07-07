using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerceWASM.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "Anna Karenina (Russian: «Анна Каренина», IPA: [ˈanːə kɐˈrʲenʲɪnə])[1] is a novel by the Russian author Leo Tolstoy, first published in book form in 1878. Widely considered to be one of the greatest works of literature ever written,[2] Tolstoy himself called it his first true novel. It was initially released in serial installments from 1875 to 1877, all but the last part appearing in the periodical The Russian Messenger.[3]", "https://images-na.ssl-images-amazon.com/images/I/41MCjKLqN9L._SY291_BO1,204,203,200_QL40_FMwebp_.jpg", 9.99m, "Anna Karenina" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, "The Brothers Karamazov (Russian: Братья Карамазовы, Brat'ya Karamazovy, pronounced [ˈbratʲjə kərɐˈmazəvɨ]), also translated as The Karamazov Brothers, is the last novel by Russian author Fyodor Dostoevsky. Dostoevsky spent nearly two years writing The Brothers Karamazov, which was published as a serial in The Russian Messenger from January 1879 to November 1880. Dostoevsky died less than four months after its publication.", "https://images-na.ssl-images-amazon.com/images/I/41HLWWP2ZWL._SY291_BO1,204,203,200_QL40_FMwebp_.jpg", 12.99m, "The Brothers Karamazov" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 3, "The Lord of the Rings is an epic[1] high-fantasy novel[a] by English author and scholar J. R. R. Tolkien. Set in Middle-earth, intended to be Earth at some distant time in the past, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.", "https://m.media-amazon.com/images/I/51bJhsl5VmL._SY346_.jpg", 14.99m, "The Lord of the Rings" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
