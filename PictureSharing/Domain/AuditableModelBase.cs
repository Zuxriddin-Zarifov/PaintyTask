using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Domain;

public class AuditableModelBase : BaseModel
{
    [Column("created_at")] public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}