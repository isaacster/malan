
using DataAccess;
using Microsoft.EntityFrameworkCore;
 

public class DbContextConnector : DbContext
{
    public DbContextConnector(DbContextOptions<DbContextConnector> options) : base(options) { }

    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<Category> Categories { get; set; }

    // Add other DbSet properties for other tables, if needed

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}