namespace DotNetWorkspace.EFCore.Persistence.Enums;

/// <summary>
///     Represents the status of a payment.
/// </summary>
public enum PaymentStatus
{
    Pending,
    Complete,
    Refunded,
    Failed,
    Cancelled
}