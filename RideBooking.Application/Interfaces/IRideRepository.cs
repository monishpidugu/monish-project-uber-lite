using RideBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Application.Interfaces
{
    public interface IRideRepository
    {
        Task<Ride?> GetRideByIdAsync(Guid rideId);
        Task<List<Driver>> GetAvailableDriversAsync();
        Task SaveChangesAsync();
        Task AddRideAsync(Ride ride);
    }
}
