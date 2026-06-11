using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Application.Exceptions;

public class InvalidRideStateException : Exception
{
    public InvalidRideStateException(string message)
        : base(message)
    {
    }
}
