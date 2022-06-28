namespace BlazorEcommerceWASM.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Books",
                    Url = "books",
                },
                new Category
                {
                    Id = 2,
                    Name = "Movies",
                    Url = "movies",
                },
                new Category
                {
                    Id = 3,
                    Name = "Music",
                    Url = "music",
                }
                );
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "Anna Karenina",
                        Description = "Anna Karenina (Russian: «Анна Каренина», IPA: [ˈanːə kɐˈrʲenʲɪnə])[1] is a novel by the Russian author Leo Tolstoy, first published in book form in 1878. Widely considered to be one of the greatest works of literature ever written,[2] Tolstoy himself called it his first true novel. It was initially released in serial installments from 1875 to 1877, all but the last part appearing in the periodical The Russian Messenger.[3]",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41MCjKLqN9L._SY291_BO1,204,203,200_QL40_FMwebp_.jpg",
                        Price = 9.99m,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "The Brothers Karamazov",
                        Description = "The Brothers Karamazov (Russian: Братья Карамазовы, Brat'ya Karamazovy, pronounced [ˈbratʲjə kərɐˈmazəvɨ]), also translated as The Karamazov Brothers, is the last novel by Russian author Fyodor Dostoevsky. Dostoevsky spent nearly two years writing The Brothers Karamazov, which was published as a serial in The Russian Messenger from January 1879 to November 1880. Dostoevsky died less than four months after its publication.",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41HLWWP2ZWL._SY291_BO1,204,203,200_QL40_FMwebp_.jpg",
                        Price = 12.99m,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "The Lord of the Rings",
                        Description = "The Lord of the Rings is an epic[1] high-fantasy novel[a] by English author and scholar J. R. R. Tolkien. Set in Middle-earth, intended to be Earth at some distant time in the past, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.",
                        ImageUrl = "https://m.media-amazon.com/images/I/51bJhsl5VmL._SY346_.jpg",
                        Price = 14.99m,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 4,
                        Title = "It's a Wonderful Life",
                        Description = "It's a Wonderful Life is a 1946 American Christmas fantasy drama film produced and directed by Frank Capra, based on the short story and booklet The Greatest Gift, which Philip Van Doren Stern self-published in 1943 and is in turn loosely based on the 1843 Charles Dickens novella A Christmas Carol.[4] The film stars James Stewart as George Bailey, a man who has given up his personal dreams, in order to help others in his community, and whose thoughts of suicide on Christmas Eve brings about the intervention of his guardian angel, Clarence Odbody (Henry Travers).",
                        ImageUrl = "https://m.media-amazon.com/images/I/71OzD09EmQL._SY445_.jpg",
                        Price = 17.99m,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 5,
                        Title = "Casablanca",
                        Description = "Casablanca is a 1942 American romantic drama film directed by Michael Curtiz, and starring Humphrey Bogart, Ingrid Bergman, and Paul Henreid. Filmed and set during World War II, it focuses on an American expatriate (Bogart) who must choose between his love for a woman (Bergman) or helping her and her husband (Henreid), a Czech resistance leader, escape from the Vichy-controlled city of Casablanca to continue his fight against the Germans. The screenplay is based on Everybody Comes to Rick's, an unproduced stage play by Murray Burnett and Joan Alison. The supporting cast features Claude Rains, Conrad Veidt, Sydney Greenstreet, Peter Lorre, and Dooley Wilson.",
                        ImageUrl = "https://m.media-amazon.com/images/I/51k3eupDstL.jpg",
                        Price = 18.99m,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 6,
                        Title = "The Seventh Seal",
                        Description = "The Seventh Seal (Swedish: Det sjunde inseglet) is a 1957 Swedish historical fantasy film written and directed by Ingmar Bergman. Set in Sweden[3][4] during the Black Death, it tells of the journey of a medieval knight (Max von Sydow) and a game of chess he plays with the personification of Death (Bengt Ekerot), who has come to take his life.",
                        Price = 17.99m,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 7,
                        Title = "Roman Candle",
                        Description = "Roman Candle is the debut studio album by American singer-songwriter Elliott Smith. It was recorded in late 1993 and released on July 14, 1994 by record label Cavity Search.",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51Es-Y9Fv7L._SX300_SY300_QL70_FMwebp_.jpg",
                        Price = 14.99m,
                        CategoryId = 3
                    },
                    new Product
                    {
                        Id = 8,
                        Title = "All Things Must Pass",
                        Description = "All Things Must Pass is the third studio album by English rock musician George Harrison. Released as a triple album in November 1970, it was Harrison's first solo work after the break-up of the Beatles in April that year.",
                        ImageUrl = "https://m.media-amazon.com/images/I/81yhPJT66vL._SY355_.jpg",
                        Price = 13.99m,
                        CategoryId = 3
                    },
                    new Product
                    {
                        Id = 9,
                        Title = "Grace",
                        Description = "Grace is the only studio album by American singer-songwriter Jeff Buckley, released on August 23, 1994, by Columbia Records. The album had poor sales and received mixed reviews at the time of its release.[4] However, in recent years it has dramatically risen in critical reputation. An extended version of the album (subtitled 'Legacy Edition'), celebrating its tenth anniversary, was released on August 23, 2004, and peaked at number 44 in the UK.",
                        ImageUrl = "https://m.media-amazon.com/images/I/81b3GHV5YAL._SY355_.jpg",
                        Price = 12.99m,
                        CategoryId = 3
                    }
                );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
