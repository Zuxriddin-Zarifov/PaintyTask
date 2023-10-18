using System.ComponentModel.DataAnnotations.Schema;
using PictureSharing.Infrastructures.Repositories;

namespace PictureSharing.Domain.Entity;

[Table("users", Schema = "picture_sharing")]
public class User : AuditableModelBase<long>
{
    [Column("password")] public string Password { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("surname")] public string Surname { get; set; }
    [ForeignKey(nameof(Photo))] public List<Photo> Photos { get; set; }
}