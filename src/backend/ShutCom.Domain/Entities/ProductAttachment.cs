namespace ShutCom.Domain.Entities;

public class ProductAttachment
{
    public int ProductId { get; set; }
    public int AttachmentId { get; set; }

    // navigation properties
    public Product Product { get; set; } = null!;
    public Attachment Attachment { get; set; } = null!;
}
