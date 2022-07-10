namespace DotNetWorkspace.EFCore.Model;

public class Customer : Entity<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    #region Order - One to Many Relationship
    public virtual ICollection<Order>? Orders { get; set; }
    #endregion
}