using MysticMadness.Model.Enums;

namespace MysticMadness.Dto;

public class OrderDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public OrderStatus Status { get; set; }

    // navigation properties
    public UserDto User { get; set; } = null!;
    public List<OrderItemDto> OrderItems { get; set; } = [];
}
