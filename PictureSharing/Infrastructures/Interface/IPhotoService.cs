using PictureSharing.Domain.Entity;

namespace PictureSharing.Infrastructures.Interface;

public interface IPhotoService
{
    public ValueTask<Photo> CreateAsync(IFormFile file, string path, long userId);
    public ValueTask<IEnumerable<Photo>> GetPhotoByUserIdAsync(long userId);
}