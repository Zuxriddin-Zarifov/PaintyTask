using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

public class PhotoService : IPhotoService
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoService(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }
    public async ValueTask<Photo> Create(IFormFile file, string path,long userId)
    {
        using StreamWriter stream = new StreamWriter(path);
        stream.Write(file);
        Photo photo = new Photo
        {
            Name = file.Name,
            UserId = userId,
        };
        return await _photoRepository.CreatAsync(photo);
    }
}