using Api.Src.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Src.Infra.Data.Mappers
{
    public class PersonMapper : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(e => e.GuestId);

            builder.HasMany(e => e.Suite)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.HostedSuiteId);

            builder.HasMany(e => e.Reserve)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.HostedSuiteId);

        }
    }
}
