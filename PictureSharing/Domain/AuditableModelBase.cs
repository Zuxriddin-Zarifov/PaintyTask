using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PictureSharing.Domain;

public class AuditableModelBase<T> : BaseModel<T>
{
    [Column("created_at"),JsonIgnore] public DateTime CreatedAt { get; set; } 

    [Column("updated_at"),JsonIgnore] public DateTime? UpdatedAt { get; set; }
}