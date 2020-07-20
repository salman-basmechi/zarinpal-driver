namespace ZarinPalDriver.Models
{
    public class PaymentRequest
    {
        public string MerchantId { get; set; }

        public string CallbackUrl { get; set; }

        public decimal Amount { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public Mode Mode { get; set; }
    }
}
