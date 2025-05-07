namespace MysticMadness.Dto;

public class OrderItemDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    // navigation properties
    public ProductDto Product { get; set; } = null!;
    public OrderDto Order { get; set; } = null!;
}
