using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            // Keyless Entity
            // @see https://docs.microsoft.com/en-us/ef/core/modeling/keyless-entity-types?tabs=data-annotations
            builder.HasNoKey();
        }
    }
}
