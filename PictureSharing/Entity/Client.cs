using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Entity;

[Table("clients", Schema = "PictureSharing")]
public class Client : AuditableModelBase
{
    [Column("name")] public string Name { get; set; }
    [Column("surname")] public string Surname { get; set; }
    [Column("user_id"), ForeignKey(nameof(User))]
    public long UserId { get; set; }
    public User User { get; set; }
}