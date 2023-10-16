using Microsoft.EntityFrameworkCore;
using PictureSharing.Entity;
using PictureSharing.Repositories.Interface;

namespace PictureSharing.Repositories;

public class UserRepository : RepositoryBase<User>,IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}