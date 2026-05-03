using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Domain.Entities
{
    public enum RideStatus
    {
        Requested,
        Accepted,
        InProgress,
        Completed,
        Cancelled
    }
}
