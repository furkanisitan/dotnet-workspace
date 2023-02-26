namespace DotNetWorkspace.EventHandling;

internal class ProductUpdatingEventArgs : EventArgs
{
    public ProductUpdatingEventArgs(Product product)
    {
        Product = product;
    }

    public Product Product { get; set; }
}