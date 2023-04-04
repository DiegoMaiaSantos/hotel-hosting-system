using Api.Src.Domain.Interfaces.Repositories;
using Api.Src.Infra.Data.Contexts.Interface;
using Api.Src.Infra.Data.Repositories;

namespace Api.Src.Infra.Ioc.Factorys
{
    public static class RepositoryFactory
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IUnitOfWork, IUnitOfWork>();
            repositories.AddScoped<IPersonHotelSystemRepository, PersonHotelSystemRepository>();
            repositories.AddScoped<IReserveHotelSystemRepository, ReserveHotelSystemRepository>();
            repositories.AddScoped<ISuiteHotelSystemRepository, SuiteHotelSystemRepository>();

            return repositories;
        }
    }
}
