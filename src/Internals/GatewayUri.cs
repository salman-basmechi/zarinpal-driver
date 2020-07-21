using System;
using ZarinPalDriver.Models;

namespace ZarinPalDriver.Internals
{
    internal static class GatewayUri
    {
        public static Uri Get(Mode mode)
        {
            string uriString;

            if (mode == Mode.Operational)
            {
                uriString = "https://www.zarinpal.com/pg/StartPay";
            }
            else
            {
                uriString = "https://sandbox.zarinpal.com/pg/StartPay";
            }

            return new Uri(uriString);
        }
    }
}
