using ZarinPalDriver.Models;

namespace ZarinPalDriver.Internals
{
    internal class BaseUriResolver : IBaseUriResolver
    {
        public string Resolve(Mode mode)
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
            }

            return null;
        }
    }
}
