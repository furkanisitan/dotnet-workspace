namespace DotNetWorkspace.EFCore.Model.Common;

public interface IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}