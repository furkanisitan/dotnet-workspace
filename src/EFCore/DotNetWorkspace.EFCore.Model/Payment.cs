namespace DotNetWorkspace.EFCore.Model;

public class Payment : Entity<int>
{
    public decimal Amount { get; set; }
    public string CardNumber { get; set; } = default!;
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    #region Order - One to One Relationship
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    #endregion
}

public enum PaymentStatus
{
    Pending,
    Complete,
    Refunded,
    Failed,
    Cancelled
}