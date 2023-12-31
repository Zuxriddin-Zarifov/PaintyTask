﻿using PictureSharing.Domain.Dtos;
using PictureSharing.Domain.Entity;

namespace PictureSharing.Services.Interface;

public interface IAuthService
{
    public ValueTask<string> LoginAsync(LoginDto dto);
    public ValueTask<User> RegistrationAsync(RegistrationDto dto);
}