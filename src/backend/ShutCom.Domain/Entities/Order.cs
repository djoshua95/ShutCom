using System.ComponentModel.DataAnnotations;
using ShutCom.Domain.Enums;

namespace ShutCom.Domain.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public OrderStatus Status { get; set; }

    // navigation properties
    public User User { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; } = [];
}