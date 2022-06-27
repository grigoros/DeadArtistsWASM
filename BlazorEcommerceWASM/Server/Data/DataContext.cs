namespace BlazorEcommerceWASM.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "Anna Karenina",
                        Description = "Anna Karenina (Russian: «Анна Каренина», IPA: [ˈanːə kɐˈrʲenʲɪnə])[1] is a novel by the Russian author Leo Tolstoy, first published in book form in 1878. Widely considered to be one of the greatest works of literature ever written,[2] Tolstoy himself called it his first true novel. It was initially released in serial installments from 1875 to 1877, all but the last part appearing in the periodical The Russian Messenger.[3]",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41MCjKLqN9L._SY291_BO1,204,203,200_QL40_FMwebp_.jpg",
                        Price = 9.99m
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "The Brothers Karamazov",
                        Description = "The Brothers Karamazov (Russian: Братья Карамазовы, Brat'ya Karamazovy, pronounced [ˈbratʲjə kərɐˈmazəvɨ]), also translated as The Karamazov Brothers, is the last novel by Russian author Fyodor Dostoevsky. Dostoevsky spent nearly two years writing The Brothers Karamazov, which was published as a serial in The Russian Messenger from January 1879 to November 1880. Dostoevsky died less than four months after its publication.",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41HLWWP2ZWL._SY291_BO1,204,203,200_QL40_FMwebp_.jpg",
                        Price = 12.99m
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "The Lord of the Rings",
                        Description = "The Lord of the Rings is an epic[1] high-fantasy novel[a] by English author and scholar J. R. R. Tolkien. Set in Middle-earth, intended to be Earth at some distant time in the past, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.",
                        ImageUrl = "https://m.media-amazon.com/images/I/51bJhsl5VmL._SY346_.jpg",
                        Price = 14.99m
                    }
                );
        }
        public DbSet<Product> Products { get; set; }
    }
}
