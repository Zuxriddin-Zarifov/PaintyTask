using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Domain;

public class BaseModel
{
    [Column("id")] public long Id { get; set; }
}