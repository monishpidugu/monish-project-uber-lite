using System;
using System.Collections.Generic;
using System.Text;

namespace RideBooking.Application.Helpers
{
    public static class GeoHelper
    {
       public static double CalculateDistance(
       double lat1, double lon1,
       double lat2, double lon2)
        {
            var dLat = lat2 - lat1;
            var dLon = lon2 - lon1;

            return Math.Sqrt(dLat * dLat + dLon * dLon);
        }
    }
}
