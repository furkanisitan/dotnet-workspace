namespace DotNetWorkspace.EFCore.Persistence.Entities.Joins;

/// <summary>
///     Represents the Join entity for the many-to-many relationship between Orders and Products.
/// </summary>
public class OrderProduct
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}