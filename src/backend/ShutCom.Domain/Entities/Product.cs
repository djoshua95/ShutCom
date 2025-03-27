using System.ComponentModel.DataAnnotations;

namespace ShutCom.Domain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Model { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdateDate { get; set; }

    // navigation properties
    public List<Attachment> Attachments { get; set; } = [];
}