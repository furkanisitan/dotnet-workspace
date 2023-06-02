namespace DotNetWorkspace.EFCore.Model;

public interface IEntityDate
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}