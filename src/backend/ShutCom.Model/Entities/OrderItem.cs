using System.ComponentModel.DataAnnotations;

namespace ShutCom.Model.Entities;

public class OrderItem
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    // navigation properties
    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}