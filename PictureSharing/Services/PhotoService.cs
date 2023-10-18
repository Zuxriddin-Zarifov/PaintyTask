using PictureSharing.Domain.Entity;
using PictureSharing.Domain.Expections;
using PictureSharing.Infrastructures.Interface;
using PictureSharing.Services.Interface;

namespace PictureSharing.Services;

public class PhotoService : IPhotoService
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUserRepository _userRepository;

    public PhotoService(IPhotoRepository photoRepository, IUserRepository userRepository)
    {
        _photoRepository = photoRepository;
        _userRepository = userRepository;
    }

    public async ValueTask<Photo> CreateAsync(IFormFile file, string filePath, long userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            throw new CustomException(404, "User not found");
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        var photo = await _photoRepository.CreatAsync(new Photo
        {
            Name = file.FileName,
            UserId = userId
        });

        filePath = Path.Combine(filePath, photo.Id.ToString());
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return photo;
    }

    public async ValueTask<IEnumerable<Photo>> GetPhotoByUserIdAsync(long userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            throw new CustomException(404, "User not found");
        return null; //user.Photos;
    }

    public async ValueTask<Photo> DeleteAsync(string path,Photo photo)
    {
        var filePath = Path.Combine(path, photo.Id.ToString());
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        else
        {
            throw new CustomException(404, "file not found");
        }

        photo = await _photoRepository.DeleteAsync(photo.Id);

        return photo;
    }
}