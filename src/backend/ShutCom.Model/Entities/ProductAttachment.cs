using System.ComponentModel.DataAnnotations;

namespace ShutCom.Model.Entities;

public class ProductAttachment : IEntity
{
    [Key]
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int AttachmentId { get; set; }

    // navigation properties
    public Product Product { get; set; } = null!;
    public Attachment Attachment { get; set; } = null!;
}
