using System.ComponentModel.DataAnnotations;
using MysticMadness.Model.Enums;

namespace MysticMadness.Model.Entities;

public class Attachment : IEntity
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