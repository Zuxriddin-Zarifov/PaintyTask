using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Domain;

public class BaseModel<T>
{
    [Column("id")] public T Id { get; set; }
}