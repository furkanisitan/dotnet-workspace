﻿using System.Collections.ObjectModel;

namespace DotNetWorkspace.EFCore.Model;

public class Product : IEntity<int>
{
    public decimal Price { get; set; }
    public string Name { get; set; } = default!;

    #region Order - Many to Many Relationship

    public ICollection<Order> Orders { get; set; } = new Collection<Order>();

    #endregion

    #region IEntity

    public int Id { get; set; }

    #endregion
}