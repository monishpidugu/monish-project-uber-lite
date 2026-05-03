using RideBooking.Application.Services;
using RideBooking.Application.DTO;

namespace RideBooking.Application.Services
{
    public interface IRideService
    {
        Task<Guid> CreateRideAsync(CreateRideRequest request);
        Task AssignDriverAsync(Guid rideId);
    }
}
