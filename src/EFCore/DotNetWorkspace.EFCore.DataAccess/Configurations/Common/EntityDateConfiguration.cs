using DotNetWorkspace.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.DataAccess.Configurations.Common;

internal abstract class EntityDateConfiguration<TEntity, TKey> : EntityConfiguration<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, IEntityDate
        where TKey : IEquatable<TKey>
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedDate).ValueGeneratedOnUpdate();
    }
}