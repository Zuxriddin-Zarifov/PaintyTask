using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;
using PictureSharing.Domain.Expections;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Services;

public class UserService : IUserService
{
    protected readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async ValueTask<User> Create(RegistrationDto dto)
    {
        User user = new User
        {
            Password = dto.Password,
            Email = dto.Email,
            Name = dto.Name,
            Surname = dto.Surname
        };
       return await _userRepository.CreatAsync(user);
    }

    public async ValueTask<User> GetUserByEmailAndPassword(string password, string email)
    {
        var user = _userRepository.DbGetSet().Where(user => user.Email == email && user.Password == password)
            .FirstOrDefault();
        if (user is not User)
            throw new CustomException(404, "Not found");
        return user;
    }
}