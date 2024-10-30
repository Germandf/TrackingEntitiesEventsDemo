using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrackingEntitiesEventsDemo.Data.Entities;
using TrackingEntitiesEventsDemo.Services;

namespace TrackingEntitiesEventsDemo.Data;

public class AppDbContext : DbContext
{
    private readonly IUserService _userService;

    public AppDbContext(DbContextOptions<AppDbContext> options, IUserService userService) : base(options)
    {
        _userService = userService;
        ChangeTracker.StateChanged += UpdateTrackableEntity;
        ChangeTracker.Tracked += UpdateTrackableEntity;
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<City> Cities { get; set; }

    private void UpdateTrackableEntity(object? sender, EntityEntryEventArgs e)
    {
        if (e.Entry.Entity is TrackableEntity trackableEntity)
        {
            var currentUser = _userService.GetCurrentUser();
            var currentDateTime = DateTime.UtcNow;
            if (e.Entry.State == EntityState.Added)
            {
                trackableEntity.CreatedBy = currentUser;
                trackableEntity.CreatedAt = currentDateTime;
            }
            else if (e.Entry.State == EntityState.Modified)
            {
                trackableEntity.UpdatedBy = currentUser;
                trackableEntity.UpdatedAt = currentDateTime;
            }
        }
    }
}
