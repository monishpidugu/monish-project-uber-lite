using RideBooking.Application.Interfaces;
using RideBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RideBooking.Infrastructure.Repositories;

public class RideRepository : IRideRepository
{
    private readonly RideDbContext _context;

    public RideRepository(RideDbContext context)
    {
        _context = context;
    }

    public async Task<Ride?> GetRideByIdAsync(Guid rideId)
    {
        return await _context.Rides.FindAsync(rideId);
    }

    public async Task<List<Driver>> GetAvailableDriversAsync()
    {
        return await _context.Drivers
            .Where(d => d.IsAvailable)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task AddRideAsync(Ride ride)
    {
        await _context.Rides.AddAsync(ride);
    }

    public async Task<Driver?> GetDriverByIdAsync(Guid driverId)
    {
        return await _context.Drivers.FindAsync(driverId);
    }
}