using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Entity;

public class BaseModel
{
    [Column("id")] public long Id { get; set; }
}