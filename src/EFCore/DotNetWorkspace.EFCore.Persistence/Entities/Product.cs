using DotNetWorkspace.EFCore.Persistence.Entities.Joins;

namespace DotNetWorkspace.EFCore.Persistence.Entities;

/// <summary>
///     Represents a product entity.
/// </summary>
public class Product
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; } = null!;

    // Many-to-Many relationship: Many Products can belong to many Orders
    // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many
    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<OrderProduct> OrderProducts { get; set; } = [];
}