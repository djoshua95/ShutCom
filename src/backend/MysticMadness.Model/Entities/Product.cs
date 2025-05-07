using System.ComponentModel.DataAnnotations;

namespace MysticMadness.Model.Entities;

public class Product : IEntity
{
    [Key]
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Model { get; set; } = string.Empty;
    public int Stock { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdateDate { get; set; }

    // navigation properties
    public List<Attachment> Attachments { get; set; } = [];
}
