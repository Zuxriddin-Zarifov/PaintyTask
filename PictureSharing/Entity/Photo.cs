using System.ComponentModel.DataAnnotations.Schema;

namespace PictureSharing.Entity;

[Table("photos", Schema = "PictureSharing")]
public class Photo : AuditableModelBase
{
    [Column("path")] public string Path { get; set; }
    [Column("root_photo")] public string RootPath { get; set; }
    [Column("client_id"), ForeignKey(nameof(Client))] public long ClientId { get; set; }
    public Client Client { get; set; }
}