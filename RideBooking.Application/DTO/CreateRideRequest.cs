using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Application.DTO
{
    public class CreateRideRequest
    {
        public Guid UserId { get; set; }

        public double PickupLat { get; set; }
        public double PickupLng { get; set; }

        public double DropLat { get; set; }
        public double DropLng { get; set; }
    }
}
