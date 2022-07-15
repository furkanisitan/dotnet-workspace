using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations;

internal abstract class EntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // By convention, when using a relational database, entity properties are mapped to table columns having the same name as the property.
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt#column-names
        builder.Property(x => x.Id).HasColumnName($"{nameof(TEntity)}Id");
    }
}