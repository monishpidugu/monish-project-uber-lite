using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } 
        public required string PhoneNumber { get; set; }
    }
}
