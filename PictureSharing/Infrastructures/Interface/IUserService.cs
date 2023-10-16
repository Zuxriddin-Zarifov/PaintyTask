
using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;

namespace PictureSharing.Infrastructures.Interface;

public interface IUserService
{
    public ValueTask<User> Create(RegistrationDto dto);
    public ValueTask<User> GetUserByEmailAndPassword(string password,string email);
}