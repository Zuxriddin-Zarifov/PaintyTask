using Microsoft.EntityFrameworkCore;
using PictureSharing.Entity;
using PictureSharing.Infrastructures.Interface;

namespace PictureSharing.Infrastructures.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
{
    private readonly DbContext _context;

    protected RepositoryBase(DbContext context)
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
            throw new Exception("Data not fount");
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