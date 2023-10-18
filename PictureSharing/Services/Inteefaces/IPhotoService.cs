using PictureSharing.Domain.Entity;

namespace PictureSharing.Services.Interface;

public interface IPhotoService
{
    public ValueTask<Photo> CreateAsync(IFormFile file, string path, long userId);
    public ValueTask<IEnumerable<Photo>> GetPhotoByUserIdAsync(long userId);
    public ValueTask<Photo> DeleteAsync(string path,Photo photo);
}
