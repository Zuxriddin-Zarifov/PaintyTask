using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Entity;

public class AuditableModelBase : BaseModel
{
    [Column("created_at")] public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}