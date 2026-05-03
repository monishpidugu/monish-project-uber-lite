using RideBooking.Application.DTO;
using RideBooking.Application.Helpers;
using RideBooking.Application.Interfaces;
using RideBooking.Domain.Entities;

namespace RideBooking.Application.Services;

public class RideService : IRideService
{
    private readonly IRideRepository _repository;

    public RideService(IRideRepository repository)
    {
        _repository = repository;
    }

    public async Task AssignDriverAsync(Guid rideId)
    {
        var ride = await _repository.GetRideByIdAsync(rideId);

        if (ride == null)
            throw new Exception("Ride not found");

        var availableDrivers = await _repository.GetAvailableDriversAsync();

        if (!availableDrivers.Any())
            throw new Exception("No drivers available");

        var nearestDriver = availableDrivers
            .OrderBy(d => GeoHelper.CalculateDistance(
                ride.Pickup.Latitude,
                ride.Pickup.Longitude,
                d.CurrentLocation.Latitude,
                d.CurrentLocation.Longitude))
            .First();

        ride.DriverId = nearestDriver.Id;
        ride.Status = RideStatus.Accepted;

        nearestDriver.IsAvailable = false;

        await _repository.SaveChangesAsync();
    }

    public async Task<Guid> CreateRideAsync(CreateRideRequest request)
    {
        var ride = new Ride
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Pickup = new Location
            {
                Latitude = request.PickupLat,
                Longitude = request.PickupLng
            },
            Drop = new Location
            {
                Latitude = request.DropLat,
                Longitude = request.DropLng
            },
            Status = RideStatus.Requested,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddRideAsync(ride);
        await _repository.SaveChangesAsync();

        return ride.Id;
    }
}