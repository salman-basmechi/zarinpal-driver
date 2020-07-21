using ZarinPalDriver.Models;

namespace ZarinPalDriver.Internals
{
    internal static class ApiBaseUri
    {
        public static string Get(Mode mode)
        {
            switch (mode)
            {
                case Mode.SandBox:
                    {
                        return "https://sandbox.zarinpal.com/pg/v4/payment";
                    }
                case Mode.Operational:
                    {
                        return "https://api.zarinpal.com/pg/v4/payment";
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
