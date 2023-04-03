using Api.Src.Infra.Data.Entities;
using Api.Src.Infra.Data.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Api.Src.Infra.Data.Contexts
{
    public class HotelSystemDbContext : DbContext 
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Suite> Suites { get; set; }
        public DbSet<Reserve> Reserves { get; set; }

        public HotelSystemDbContext(DbContextOptions<HotelSystemDbContext> options) : base(options)
        {
        }

        private static void ApplyMappers(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMapper());
            modelBuilder.ApplyConfiguration(new SuiteMapper());
            modelBuilder.ApplyConfiguration(new ReserveMapper());            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyMappers(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
