using DotNetWorkspace.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations.Common;

internal abstract class EntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public abstract string TableName { get; }

    public virtual string IdColumnName => $"{typeof(TEntity).Name}Id";

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // By convention, each entity type will be set up to map to a database table with the same name as the DbSet property that exposes the entity.
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=data-annotations#table-name
        builder.ToTable(TableName);

        // By convention, a property named Id or <type name>Id will be configured as the primary key of an entity.
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=fluent-api#configuring-a-primary-key
        // By convention, on relational databases primary keys are created with the name PK_<type name>. 
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations#primary-key-name
        builder.HasKey(x => x.Id).HasName($"PK_{TableName}_{IdColumnName}");

        // By convention, when using a relational database, entity properties are mapped to table columns having the same name as the property.
        // @see https://docs.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt#column-names
        builder.Property(x => x.Id).HasColumnName($"{IdColumnName}");
    }
}