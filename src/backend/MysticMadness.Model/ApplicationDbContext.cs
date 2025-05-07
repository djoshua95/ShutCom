using Microsoft.EntityFrameworkCore;
using MysticMadness.Model.Entities;

namespace MysticMadness.Model;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Attachment> Attachments { get; set; } = null!;
    public DbSet<ProductAttachment> ProductAttachments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Price).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Attachments)
            .WithMany()
            .UsingEntity<ProductAttachment>(
                r => r.HasOne(pa => pa.Attachment).WithMany().HasForeignKey(pa => pa.AttachmentId),
                l => l.HasOne(pa => pa.Product).WithMany().HasForeignKey(pa => pa.ProductId)
            );
    }
}
