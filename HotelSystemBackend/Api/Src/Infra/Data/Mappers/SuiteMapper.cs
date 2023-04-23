using Api.Src.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Src.Infra.Data.Mappers
{
    public class SuiteMapper : IEntityTypeConfiguration<Suite>
    {
        public void Configure(EntityTypeBuilder<Suite> builder)
        {

        }
    }
}
