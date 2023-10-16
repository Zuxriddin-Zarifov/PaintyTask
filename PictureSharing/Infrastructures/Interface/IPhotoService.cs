using PictureSharing.Domain.Entity;

namespace PictureSharing.Infrastructures.Interface;

public interface IPhotoService
{
    public ValueTask<Photo> Create(IFormFile file, string path, long userId);
}