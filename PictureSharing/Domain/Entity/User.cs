using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Domain.Entity;

[Table("users", Schema = "picture_sharing")]
public class User : AuditableModelBase
{
    [Column("password")] public string Password { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("surname")] public string Surname { get; set; }
}