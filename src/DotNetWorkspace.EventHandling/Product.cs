namespace DotNetWorkspace.EventHandling;

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public override string ToString()
    {
        return $"Id: '{Id}', Name: '{Name}', CreatedDate: '{CreatedDate}', UpdatedDate: '{UpdatedDate}'";
    }
}