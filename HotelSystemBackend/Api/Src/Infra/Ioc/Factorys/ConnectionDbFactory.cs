using Api.Config.Environments;
using Api.Src.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Src.Infra.Ioc.Factorys
{
    public static class ConnectionDbFactory
    {
        public static IServiceCollection RegisterDbConnections(this IServiceCollection connections)
        {
            connections.AddDbContext<HotelSystemDbContext>(options =>
            {
                options.UseSqlServer(Constants.ConnectionStringHotelSystem);
            });

            return connections;
        }
    }
}
