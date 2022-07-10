namespace DotNetWorkspace.EFCore.Model;

public abstract class Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}