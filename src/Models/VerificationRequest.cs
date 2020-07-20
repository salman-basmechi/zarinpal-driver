namespace ZarinPalDriver.Models
{
    public class VerificationRequest
    {
        public string MerchantId { get; set; }

        public decimal Amount { get; set; }

        public string Authority { get; set; }

        public Mode Mode { get; set; }
    }
}
