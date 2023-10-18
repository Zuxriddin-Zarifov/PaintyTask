using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PictureSharing.Domain;
using PictureSharing.Domain.Entity;

namespace PictureSharing.Infrastructures;

public class DataContext : DbContext
{
    protected DbSet<User> Users { get; set; }
    protected DbSet<Photo> Photos { get; set; }
    protected DbSet<Friend> Friends { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public override int SaveChanges()
    {
        TrackEntities();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        TrackEntities();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        TrackEntities();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        TrackEntities();
        return base.SaveChangesAsync(cancellationToken);
    }
    

    public void TrackEntities()
    {
        var updatedEntriesLong = this.ChangeTracker
            .Entries()
            .Where(x => (x.State == EntityState.Added
                         || x.State == EntityState.Modified)
                        && x.Entity.GetType().BaseType is not null
                        && x.Entity.GetType().BaseType == typeof(AuditableModelBase<long>));
        var updatedEntriesGuid = this.ChangeTracker
            .Entries()
            .Where(x => (x.State == EntityState.Added
                         || x.State == EntityState.Modified)
                        && x.Entity.GetType().BaseType is not null
                        && x.Entity.GetType().BaseType == typeof(AuditableModelBase<Guid>));
        TrackEntitiesLong(updatedEntriesLong);
        TrackEntitiesGuid(updatedEntriesGuid);

    }

    public void TrackEntitiesGuid(IEnumerable<EntityEntry> updatedEntries)
    {
        
        foreach (var entityEntry in updatedEntries)
        {
            var entity = (AuditableModelBase<Guid>)entityEntry.Entity;
            if (entityEntry.State == EntityState.Added)
                entity.CreatedAt = DateTime.Now;
            else
                entity.UpdatedAt = DateTime.Now;
        }
    }

    public void TrackEntitiesLong(IEnumerable<EntityEntry> updatedEntries)
    {
        foreach (var entityEntry in updatedEntries)
        {
            var entity = (AuditableModelBase<long>)entityEntry.Entity;
            if (entityEntry.State == EntityState.Added)
                entity.CreatedAt = DateTime.Now;
            else
                entity.UpdatedAt = DateTime.Now;
        }
    }
}