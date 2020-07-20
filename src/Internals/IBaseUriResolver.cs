using ZarinPalDriver.Models;

namespace ZarinPalDriver.Internals
{
    internal interface IBaseUriResolver
    {
        string Resolve(Mode mode);
    }
}
