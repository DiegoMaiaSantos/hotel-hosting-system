using Api.Src.Domain.Interfaces.Services;
using Api.Src.Services;

namespace Api.Src.Infra.Ioc.Factorys
{
    public static class ServiceFactory
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonHotelSystemService, PersonHotelSystemService>();
            services.AddScoped<IReserveHotelSystemService, ReserveHotelSystemService>();
            services.AddScoped<ISuiteHotelSystemService, SuiteHotelSystemService>();

            return services;
        }
    }
}
