using Microsoft.Extensions.DependencyInjection;
using XamaSistemas.Cielo.Ecommerce;

namespace XamaSistemas.Cielo
{
    public static class CieloBootstrap
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<CieloEcommerce>();
        }
    }
}
