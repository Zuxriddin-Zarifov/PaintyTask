using Microsoft.EntityFrameworkCore;
using PictureSharing.Entity;

namespace PictureSharing.Infrastructures;

public class DataContext : DbContext
{
    protected DbSet<User> Users { get; set; }
    protected DbSet<Client> Clients { get; set; }
    protected DbSet<Photo> Photos { get; set; }
    protected DbSet<Friends> Friends { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}