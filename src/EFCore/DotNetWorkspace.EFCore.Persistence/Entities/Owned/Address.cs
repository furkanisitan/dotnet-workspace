namespace DotNetWorkspace.EFCore.Persistence.Entities.Owned;

/// <summary>
///     Represents an address entity.
/// </summary>
/// <remarks>
///     This class is used as an owned entity in Entity Framework Core.
///     For more information, see
///     <see href="https://learn.microsoft.com/en-us/ef/core/modeling/owned-entities">Owned Entities</see>.
/// </remarks>
public class Address
{
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string Detail { get; set; } = null!;
}