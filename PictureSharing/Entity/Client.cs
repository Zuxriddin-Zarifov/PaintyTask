using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Entity;
[Table("clients",Schema = "PictureSharing")]
public class Client : AuditableModelBase
{
    [Column("user_id"), ForeignKey(nameof(User))] public long UserId { get; set; }
    public User User { get; set; }
    [ForeignKey(nameof(Photo))] public List<Photo> Photos { get; set; }
}