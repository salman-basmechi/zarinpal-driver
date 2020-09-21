namespace ZarinPalDriver.Models
{
    public class PaymentRequest
    {
        public string MerchantId { get; set; }

        public Mode Mode { get; set; }

        public string CallbackUrl { get; set; }

        public decimal Amount { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Create from default options. <para />
        /// MerchantId and Mode properties set by default configuration values.
        /// </summary>
        /// <returns></returns>
        public static PaymentRequest CreateDefault()
        {
            return new PaymentRequest
            {
                MerchantId = ZarinPalOptions.Default.MerchantId,
                Mode = ZarinPalOptions.Default.Mode
            };
        }
    }
}
