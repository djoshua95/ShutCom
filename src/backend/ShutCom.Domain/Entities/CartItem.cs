using System.ComponentModel.DataAnnotations;

namespace ShutCom.Domain.Entities;

public class CartItem
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }

    // navigation properties
    public User User { get; set; } = null!;
    public Product Product { get; set; } = null!;
}