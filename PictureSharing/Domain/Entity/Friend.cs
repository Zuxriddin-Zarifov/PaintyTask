using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PictureSharing.Domain.Enum;

namespace PictureSharing.Domain.Entity;

[Table("friends", Schema = "picture_sharing")]
public class Friend : AuditableModelBase<long>
{
    [Column("user_id"), ForeignKey(nameof(Owner))]
    public long UserId { get; set; }

    [JsonIgnore] public User Owner { get; set; }

    [Column("friend_id"), ForeignKey(nameof(Friends))]
    public long FriendId { get; set; }

    [JsonIgnore] public User Friends { get; set; }

    [Column("status")] public FriendsStatus Status { get; set; }
}