using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Entity;

[Table("users", Schema = "PictureSharing")]
public class User : AuditableModelBase
{
    [Column("password")] public string Password { get; set; }
    [Column("email")] public string Email { get; set; }
}