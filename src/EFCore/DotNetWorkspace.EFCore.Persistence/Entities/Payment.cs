using DotNetWorkspace.EFCore.Persistence.Enums;

namespace DotNetWorkspace.EFCore.Persistence.Entities;

/// <summary>
///     Represents a payment entity.
/// </summary>
public class Payment
{
    public int Id { get; set; }
    public string CardNumber { get; set; } = null!;
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    // One-to-One relationship: One Payment (Dependent/Child) is associated with one Order (Principal/Parent)
    // @see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-one
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
}