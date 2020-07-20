using Microsoft.Extensions.DependencyInjection;
using ZarinPalDriver.Internals;

namespace ZarinPalDriver
{
    public static class ServiceCollectionExtentions
    {
        public static void AddZarinPalDriver(this IServiceCollection services)
        {
            services.AddSingleton<IZarinPalClient, ZarinPalClient>();

            services.AddSingleton<IBaseUriResolver, BaseUriResolver>();
        }
    }
}
