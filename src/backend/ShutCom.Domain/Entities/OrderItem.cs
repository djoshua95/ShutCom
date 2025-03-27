using System.ComponentModel.DataAnnotations;

namespace ShutCom.Domain.Entities;

public class OrderItem
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    
    // navigation properties
    public Product Product { get; set; } = null!;
}