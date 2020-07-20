using System;

namespace ZarinPalDriver.Models
{
    public class PaymentResponse
    {
        public PaymentResponse(string authority, Status status, Uri gatewayUri)
        {
            Authority = authority;
            Status = status;
            GatewayUri = gatewayUri ?? throw new ArgumentNullException(nameof(gatewayUri));
        }

        public string Authority { get; }

        public Status Status { get; }

        public Uri GatewayUri { get; }
    }
}
