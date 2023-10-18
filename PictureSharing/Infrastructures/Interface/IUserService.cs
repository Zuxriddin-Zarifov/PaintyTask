﻿
using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;

namespace PictureSharing.Infrastructures.Interface;

public interface IUserService
{
    public ValueTask<User> CreateAsync(RegistrationDto dto);
    public ValueTask<User> GetUserByEmailAndPasswordAsync(string password,string email);
}