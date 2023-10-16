using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Entity;

[Table("users",Schema = "PictureSharing")]
public class User : AuditableModelBase
{
    [Column("name")] public string Name { get; set; }
    [Column("surname")] public string Surname { get; set; }
    [Column("phone")] public string Phone { get; set; }
    [Column("email")] public string Email { get; set; }
}