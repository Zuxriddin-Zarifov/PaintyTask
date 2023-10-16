﻿using Microsoft.EntityFrameworkCore;
using PictureSharing.Entity;

namespace PictureSharing.Infrastructures.Interface;

public interface IRepositoryBase<T> where T : BaseModel
{
    public DbSet<T> DbGetSet();
    public ValueTask<IEnumerable<T>> GetAllAsync();
    public ValueTask<T> GetByIdAsync(long id);
    public ValueTask<T> CreatAsync(T data);
    public ValueTask<T> UpdateAsync(T data);
    public ValueTask<T> DeleteAsync(long id);
}