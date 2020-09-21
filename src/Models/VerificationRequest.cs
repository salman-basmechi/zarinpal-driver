namespace ZarinPalDriver.Models
{
    public class VerificationRequest
    {
        public string MerchantId { get; set; }

        public Mode Mode { get; set; }

        public decimal Amount { get; set; }

        public string Authority { get; set; }

        /// <summary>
        /// Create from default options. <para />
        /// MerchantId and Mode properties set by default configuration values.
        /// </summary>
        /// <returns></returns>
        public static VerificationRequest CreateDefault()
        {
            return new VerificationRequest
            {
                MerchantId = ZarinPalOptions.Default.MerchantId,
                Mode = ZarinPalOptions.Default.Mode
            };
        }
    }
}
