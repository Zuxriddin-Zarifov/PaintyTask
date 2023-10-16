using Microsoft.EntityFrameworkCore;
using PictureSharing.Domain;
using PictureSharing.Domain.Expections;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
{
    private readonly DataContext _context;

    protected RepositoryBase(DataContext context)
    {
        _context = context;
    }

    public DbSet<T> DbGetSet()
    {
        return _context.Set<T>();
    }

    public async ValueTask<IEnumerable<T>> GetAllAsync()
    {
        return await DbGetSet().ToListAsync();
    }

    public async ValueTask<T> GetByIdAsync(long id)
    {
        var data = await DbGetSet().Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data is null)
            throw new CustomException(404,"Data not fount");
        return data;
    }

    public async ValueTask<T> CreatAsync(T data)
    {
        var entityResult = DbGetSet().Add(data);
        await _context.SaveChangesAsync();
        return entityResult.Entity;
    }

    public async ValueTask<T> UpdateAsync(T data)
    {
        var entityResult = DbGetSet().Update(data);
        await _context.SaveChangesAsync();
        return entityResult.Entity;
    }

    public async ValueTask<T> DeleteAsync(long id)
    {
        var data = await GetByIdAsync(id);
        var entityResult = DbGetSet().Remove(data);
        await _context.SaveChangesAsync();
        return entityResult.Entity;
    }
}