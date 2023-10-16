using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Domain.Entity;

[Table("photos", Schema = "picture_sharing")]
public class Photo : AuditableModelBase
{
    [Column("name")] public string Name { get; set; }

    [Column("user_id"), ForeignKey(nameof(User))] public long UserId { get; set; }
    public User User { get; set; }
}