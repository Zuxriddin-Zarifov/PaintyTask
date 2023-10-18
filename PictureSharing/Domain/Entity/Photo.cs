using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PictureSharing.Domain.Entity;

[Table("photos", Schema = "picture_sharing")]
public class Photo : AuditableModelBase<Guid>
{
    [Column("name")] public string Name { get; set; }

    [Column("user_id"), ForeignKey(nameof(User))]
    public long UserId { get; set; }

    [JsonIgnore] public User User { get; set; }
}