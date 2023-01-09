using Microsoft.EntityFrameworkCore;

namespace Module4.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set;}

        protected void OnModelCreateing(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Raspberry", ProductPrice = 123.44, Description = "how to make pies", ProductImageName = "bodie.jpg" },
                new Product { ProductId = 2, Name = "C++ how to", ProductPrice = 66.44, Description = "how to C++", ProductImageName = "bodie.jpg" },
                new Product { ProductId = 3, Name = "Yankee work for Yankees", ProductPrice = 12.44, Description = "book about yankees", ProductImageName = "bodie.jpg" },
                new Product { ProductId = 4, Name = "Book of Objections", ProductPrice = 99.99, Description = "Just pictures of people objecting ", ProductImageName = "bodie.jpg" }
            );
        }

    }
    
}
