namespace PictureSharing.Entity.Dtos;

public class ClientCreateDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public long UserId { get; set; }
    public IFormFile Photo { get; set; }
    public bool RootPhoto { get; set; } = false;
}