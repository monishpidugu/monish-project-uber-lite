namespace RideBooking.Infrastructure;

using Microsoft.EntityFrameworkCore;
using RideBooking.Domain.Entities;

public class RideDbContext : DbContext
{
    public RideDbContext(DbContextOptions<RideDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Ride> Rides { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ride>(entity =>
        {
            entity.OwnsOne(r => r.Pickup);
            entity.OwnsOne(r => r.Drop);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.OwnsOne(d => d.CurrentLocation);
        });
    }
}
