using PictureSharing.Domain.Entity;
using PictureSharing.Domain.Expections;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

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

        var photo = new Photo
        {
            Name = file.FileName,
            UserId = userId
        };

        filePath = Path.Combine(filePath, photo.Id.ToString());
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return await _photoRepository.CreatAsync(photo);
    }

    public async ValueTask<IEnumerable<Photo>> GetPhotoByUserIdAsync(long userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
            throw new CustomException(404, "User not found");
        return user.Photos;
    }
}