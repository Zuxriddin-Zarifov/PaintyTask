using PictureSharing.Entity;
using PictureSharing.Entity.Dtos;

namespace PictureSharing.Infrastructures.Interface;

public interface IUserService
{
    public ValueTask<User> Create(UserCreateDto dto);
}