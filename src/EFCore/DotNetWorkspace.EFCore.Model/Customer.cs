using DotNetWorkspace.Entities;
using System.Collections.ObjectModel;

namespace DotNetWorkspace.EFCore.Model;

public class Customer : IEntity<int>
{
    #region IEntity
    public int Id { get; set; }
    #endregion

    public string Username { get; set; } = default!;

    public Person Person { get; set; } = new();

    #region Order - One to Many Relationship
    public ICollection<Order> Orders { get; set; } = new Collection<Order>();
    #endregion

}