namespace DotNetWorkspace.EFCore.Model;

public class Order : Entity<int>
{
    public decimal TotalPrice { get; set; }
    public string Address { get; set; } = null!;

    #region Payment - One to One Relationship
    public Payment Payment { get; set; } = null!;
    #endregion

    #region Customer - Many to One Relationship
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    #endregion

    #region Product - Many to Many Relationship
    public virtual ICollection<Product>? Products { get; set; }
    #endregion
}