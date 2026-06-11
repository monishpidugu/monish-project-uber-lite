using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Application.Exceptions;

public class NoDriversAvailableException : Exception
{
    public NoDriversAvailableException(string message)
        : base(message)
    {
    }
}
