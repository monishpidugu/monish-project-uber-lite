using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using RideBooking.Application.Interfaces;
using RideBooking.Domain.Entities;
using RideBooking.Infrastructure;

namespace RideBooking.Application.Services;

public class VehicleTypeService : IVehicleTypeService
{
    private readonly RideDbContext _context;
    private readonly IMemoryCache _cache;

    private const string VehicleTypesCacheKey = "vehicle-types";

    public VehicleTypeService(
        RideDbContext context,
        IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<List<VehicleType>> GetVehicleTypesAsync()
    {
        if (_cache.TryGetValue(
                VehicleTypesCacheKey,
                out List<VehicleType>? vehicleTypes))
        {
            return vehicleTypes!;
        }

        vehicleTypes = await _context.VehicleTypes.ToListAsync();

        _cache.Set(
            VehicleTypesCacheKey,
            vehicleTypes,
            TimeSpan.FromMinutes(30));

        return vehicleTypes;
    }
}