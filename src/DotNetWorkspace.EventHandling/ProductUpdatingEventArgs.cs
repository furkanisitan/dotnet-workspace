namespace DotNetWorkspace.EventHandling;

internal class ProductUpdatingEventArgs(Product product) : EventArgs
{
    public Product Product { get; set; } = product;
}