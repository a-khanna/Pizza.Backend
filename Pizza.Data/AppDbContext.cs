using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities;

namespace Pizza.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Domain.Entities.Pizza> Pizzas { get; set; }
    public DbSet<Side> Sides { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Pizzas)
            .WithOne();

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Sides)
            .WithOne();

        modelBuilder.Entity<Domain.Entities.Pizza>()
            .HasMany(p => p.Ingredients)
            .WithMany(i => i.Pizzas);
    }
}
