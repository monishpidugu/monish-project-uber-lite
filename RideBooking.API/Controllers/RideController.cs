using Microsoft.AspNetCore.Mvc;
using RideBooking.Application.DTO;
using RideBooking.Application.Services;

namespace RideBooking.API.Controllers;

[ApiController]
[Route("api/rides")]
public class RideController : ControllerBase
{
    private readonly IRideService _rideService;

    public RideController(IRideService rideService)
    {
        _rideService = rideService;
    }

    // ✅ CREATE RIDE
    [HttpPost]
    public async Task<IActionResult> CreateRide(CreateRideRequest request)
    {
        var rideId = await _rideService.CreateRideAsync(request);
        return Ok(rideId);
    }

    // ✅ ASSIGN DRIVER
    [HttpPost("{rideId}/assign-driver")]
    public async Task<IActionResult> AssignDriver(Guid rideId)
    {
        await _rideService.AssignDriverAsync(rideId);
        return Ok("Driver assigned successfully");
    }
}