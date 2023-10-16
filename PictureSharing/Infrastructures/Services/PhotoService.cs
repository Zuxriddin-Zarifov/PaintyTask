using PictureSharing.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

public class PhotoService : IPhotoService
{
    public async ValueTask<Photo> Create(IFormFile file)
    {
        throw new NotImplementedException();
    }
}