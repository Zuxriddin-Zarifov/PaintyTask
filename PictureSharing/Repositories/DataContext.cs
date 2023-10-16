using Microsoft.EntityFrameworkCore;
using PictureSharing.Entity;

namespace PictureSharing.Repositories;

public class DataContext : DbContext
{
    protected DbSet<User> Users { get; set; }
    protected DbSet<Client> Clients { get; set; }
    protected DbSet<Photo> Photos { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}