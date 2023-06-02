using System.Collections.ObjectModel;

namespace DotNetWorkspace.EFCore.Model;

public class Order : IEntity<int>, IEntityDate
{
    public decimal TotalPrice { get; set; }
    public string Address { get; set; } = default!;

    #region Payment - One to One Relationship

    public Payment Payment { get; set; } = default!;

    #endregion

    #region Product - Many to Many Relationship

    public ICollection<Product> Products { get; set; } = new Collection<Product>();

    #endregion

    #region IEntity

    public int Id { get; set; }

    #endregion

    #region IEntityDate

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    #endregion

    #region Customer - Many to One Relationship

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;

    #endregion
}