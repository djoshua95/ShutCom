using System.ComponentModel.DataAnnotations;
using MysticMadness.Model.Enums;

namespace MysticMadness.Model.Entities;

public class Order : IEntity
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public OrderStatus Status { get; set; }

    // navigation properties
    public User User { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; } = [];
}