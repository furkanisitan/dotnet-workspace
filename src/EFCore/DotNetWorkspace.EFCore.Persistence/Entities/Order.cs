using DotNetWorkspace.EFCore.Persistence.Entities.Joins;
using DotNetWorkspace.EFCore.Persistence.Entities.Owned;

namespace DotNetWorkspace.EFCore.Persistence.Entities;

/// <summary>
///     Represents an order entity.
/// </summary>
public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal DiscountAmount { get; set; }

    // Owned Entity: Address is an owned entity of Order
    // @see https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities
    public Address Address { get; set; } = null!;

    // One-to-One relationship: One Order (Principal/Parent) has one Payment (Dependent/Child)
    // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-one
    public Payment? Payment { get; set; }

    // Many-to-One relationship: Many Orders (Dependent/Child) can belong to one Customer (Principal/Parent)
    // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // Many-to-Many relationship: Many Orders can have many Products
    // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<OrderProduct> OrderProducts { get; set; } = [];
}