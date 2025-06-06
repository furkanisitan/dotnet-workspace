﻿using DotNetWorkspace.EFCore.Persistence.Entities;
using DotNetWorkspace.EFCore.Persistence.Entities.Owned;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetWorkspace.EFCore.Persistence.EntityConfigurations.Owned;

internal static class AddressEntityConfiguration
{
    public static Action<OwnedNavigationBuilder<Order, Address>> ForOrder = builder =>
    {
        builder.ToTable("Addresses");
        builder.HasKey(x => x.OrderId);

        builder.WithOwner(x => x.Order).HasForeignKey(x => x.OrderId);

        // @see https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=fluent-api%2Cwithout-nrt#maximum-length
        builder.Property(x => x.City).HasMaxLength(100);
        builder.Property(x => x.Street).HasMaxLength(100);
        builder.Property(x => x.Detail).HasMaxLength(255);
    };
}