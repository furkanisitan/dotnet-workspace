namespace DotNetWorkspace.EFCore.Persistence.Entities.Views;

/// <summary>
///     Represents the result of a view that counts the number of orders for each product.
/// </summary>
/// <remarks>
///     This class is used as a keyless entity in Entity Framework Core.
///     For more information, see
///     <see href="https://learn.microsoft.com/en-us/ef/core/modeling/keyless-entity-types">Keyless Entity Types</see>.
/// </remarks>
public class ProductOrdersCount
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int OrderCount { get; set; }
}