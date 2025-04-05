namespace DotNetWorkspace.EventHandling;

internal struct ProductAddingEventArgs(Product product)
{
    public Product Product { get; set; } = product;
}