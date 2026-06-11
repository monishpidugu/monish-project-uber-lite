using System;
using System.Collections.Generic;
using System.Text;
using RideBooking.Domain.Entities;

namespace RideBooking.Application.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<List<VehicleType>> GetVehicleTypesAsync();
    }
}
