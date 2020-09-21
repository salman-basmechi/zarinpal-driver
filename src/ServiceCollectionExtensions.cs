using Microsoft.Extensions.DependencyInjection;
using ZarinPalDriver.Internals;

namespace ZarinPalDriver
{
    public static class ServiceCollectionExtensions
    {
        public static void AddZarinPalDriver(this IServiceCollection services)
        {
            services.AddSingleton<IZarinPalClient, ZarinPalClient>();
        }
    }
}
