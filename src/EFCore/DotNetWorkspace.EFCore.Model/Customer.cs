namespace DotNetWorkspace.EFCore.Model;

public class Customer : IEntity<int>
{
    #region IEntity
    public int Id { get; set; }
    #endregion

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    #region Order - One to Many Relationship
    public virtual ICollection<Order>? Orders { get; set; }
    #endregion

}