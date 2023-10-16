using System.ComponentModel.DataAnnotations.Schema;
using PictureSharing.Domain.Enum;

namespace PictureSharing.Domain.Entity;

[Table("friends", Schema = "picture_sharing")]
public class Friend : AuditableModelBase
{
    [Column("user_id"),ForeignKey(nameof(User))] public long UserId { get; set; }
    [Column("friend_id"),ForeignKey(nameof(User))] public long FriendId { get; set; }
    [Column("status")] public FriendsStatus Status { get; set; }
    
}