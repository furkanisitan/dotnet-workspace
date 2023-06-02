namespace DotNetWorkspace.EFCore.Model;

public class City : IKeylessEntity
{
    public string Name { get; set; } = default!;

    public short Plate { get; set; }
}