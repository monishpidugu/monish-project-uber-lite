using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Application.Exceptions;

public class RideNotFoundException : Exception
{
    public RideNotFoundException(string message)
        : base(message)
    {
    }
}
