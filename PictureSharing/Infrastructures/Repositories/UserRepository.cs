﻿using PictureSharing.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}