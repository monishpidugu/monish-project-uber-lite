using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Domain.Entities
{
    public class Driver
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string VehicleNumber { get; set; }
        public bool IsAvailable { get; set; }

        public Location CurrentLocation { get; set; } = new();
    }
}
