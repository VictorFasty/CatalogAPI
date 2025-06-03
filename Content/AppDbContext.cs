using CatalogoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Content;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base ( options )
    {
                
    }

    public DbSet<Catergory>? Cartegories { get; set; }
    public DbSet<Product>? Products { get; set; }

}
