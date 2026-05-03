using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Domain.Entities
{
    public class Ride
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? DriverId { get; set; }

        public required Location Pickup { get; set; }
        public required Location Drop { get; set; }

        public RideStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
