namespace DotNetWorkspace.EFCore.Model;

public class Product
{
    public decimal Price { get; set; }
    public string Name { get; set; } = default!;

    #region Order - Many to Many Relationship
    public virtual ICollection<Order>? Orders { get; set; }
    #endregion
}