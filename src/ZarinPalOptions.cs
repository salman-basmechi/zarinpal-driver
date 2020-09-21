using System;
using ZarinPalDriver.Models;

namespace ZarinPalDriver
{
    public class ZarinPalOptions
    {
        internal static ZarinPalOptions Default { get; private set; } = new ZarinPalOptions();

        public string MerchantId { get; set; }

        public Mode Mode { get; set; }

        internal static void ConfigureDefault(ZarinPalOptions options)
        {
            if (ConfiguredBefore())
            {
                throw new InvalidOperationException($"{nameof(ZarinPalOptions)} must be configured once.");
            }

            if (options != null)
            {
                Default = options;
            }
        }

        private static bool ConfiguredBefore() => Default.MerchantId != default;
    }
}
