namespace DotNetWorkspace.EventHandling;

internal struct ProductAddingEventArgs
{
    public ProductAddingEventArgs(Product product)
    {
        Product = product;
    }

    public Product Product { get; set; }
}