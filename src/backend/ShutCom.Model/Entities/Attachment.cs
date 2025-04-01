using System.ComponentModel.DataAnnotations;
using ShutCom.Model.Enums;

namespace ShutCom.Model.Entities;

public class Attachment
{
    [Key]
    public int Id { get; set; }
    public string Link { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AttachmentType Type { get; set; }
    public string Format { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
}