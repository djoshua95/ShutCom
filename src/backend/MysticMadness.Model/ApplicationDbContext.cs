using Microsoft.EntityFrameworkCore;
using MysticMadness.Model.Entities;

namespace MysticMadness.Model;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<ProductAttachment> ProductAttachments { get; set; }

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