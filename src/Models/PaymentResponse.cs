namespace ZarinPalDriver.Models
{
    public class PaymentResponse
    {
        public PaymentResponse(string authority, Status status)
        {
            Authority = authority;
            Status = status;
        }

        public string Authority { get; }

        public Status Status { get; }
    }
}
