using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Entity;

[Table("friends", Schema = "PictureSharing")]
public class Friends : BaseModel
{
    [Column("from_id"),ForeignKey(nameof(Client))]
    public long FromId { get; set; }
    [Column("to_id"),ForeignKey(nameof(Client))]
    public long ToId { get; set; }
}