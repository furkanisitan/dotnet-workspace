using DotNetWorkspace.EFCore.Model.Common;

namespace DotNetWorkspace.EFCore.Model;

public class Payment : IEntity<int>, IEntityDate
{
    #region IEntity
    public int Id { get; set; }
    #endregion

    #region IEntityDate
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    #endregion

    public decimal Amount { get; set; }
    public string CardNumber { get; set; } = default!;
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    #region Order - One to One Relationship
    //public int OrderId { get; set; }
    public Order Order { get; set; } = default!;
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