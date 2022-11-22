namespace DotNetWorkspace.Entities;

public interface IEntityDate
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}