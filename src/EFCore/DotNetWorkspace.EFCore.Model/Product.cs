using DotNetWorkspace.EFCore.Model.Common;
using System.Collections.ObjectModel;

namespace DotNetWorkspace.EFCore.Model;

public class Product : IEntity<int>
{
    #region IEntity
    public int Id { get; set; }
    #endregion

    public decimal Price { get; set; }
    public string Name { get; set; } = default!;

    #region Order - Many to Many Relationship
    public ICollection<Order> Orders { get; set; } = new Collection<Order>();
    #endregion

}