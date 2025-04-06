namespace DotNetWorkspace.EFCore.Persistence.Entities;

/// <summary>
///     Represents a customer entity.
/// </summary>
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    // One-to-Many relationship: One Customer (Principal/Parent) can have many Orders (Dependent/Child)
    // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-many
    public ICollection<Order> Orders { get; set; } = [];
}