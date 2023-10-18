using PictureSharing.Domain.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class UserRepository : RepositoryBase<User,long>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}