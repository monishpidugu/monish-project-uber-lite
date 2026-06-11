using Microsoft.AspNetCore.Mvc;
using RideBooking.Application.Interfaces;

namespace RideBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleTypesController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypesController(IVehicleTypeService vehicleTypeService)
        {

            _vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleTypes()
        {
            var vehicleTypes = await _vehicleTypeService.GetVehicleTypesAsync();

            return Ok(vehicleTypes);
        }

    }
}
