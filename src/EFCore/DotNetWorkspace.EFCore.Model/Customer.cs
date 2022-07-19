namespace DotNetWorkspace.EFCore.Model;

public class Customer : IEntity<int>
{
    #region IEntity
    public int Id { get; set; }
    #endregion

    public Person Person { get; set; } = new();

    #region Order - One to Many Relationship
    public virtual ICollection<Order>? Orders { get; set; }
    #endregion

}