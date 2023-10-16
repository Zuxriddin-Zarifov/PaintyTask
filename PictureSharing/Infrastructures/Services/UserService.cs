using PictureSharing.Entity;
using PictureSharing.Entity.Dtos;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async ValueTask<User> Create(UserCreateDto dto)
    {
        User user = new User()
        {
            CreatedAt = DateTime.Now,
            Email = dto.Email,
            Password = dto.Password
        };
        return await _userRepository.CreatAsync(user);
    }
}