using Microsoft.EntityFrameworkCore;
using CRM.Domain.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Deal> Deals { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Deal>()
            .HasOne(d => d.User)
            .WithMany(u => u.Deals)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Deal>()
            .HasOne(d => d.Receiver)
            .WithMany()
            .HasForeignKey(d => d.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Deal>()
            .Property(d => d.Amount)
            .HasPrecision(18, 2); 

    }
}
