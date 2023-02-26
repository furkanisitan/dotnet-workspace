namespace DotNetWorkspace.EventHandling;

internal class ProductRepository
{
    public delegate void ProductUpdatingEventHandler(object sender, ProductUpdatingEventArgs e);

    private static readonly List<Product> Products = new();

    // good
    public event EventHandler<ProductAddingEventArgs>? Adding; // dotnet standard
    public event Action<object, ProductAddingEventArgs>? Added; // dotnet core

    // bad
    public event ProductUpdatingEventHandler? Updating;
    public event ProductUpdatingEventHandler? Updated;
       
    public Product Add(Product product)
    {
        Adding?.Invoke(this, new ProductAddingEventArgs(product));

        product.Id = Products.Any() ? Products.Max(x => x.Id) + 1 : 1;
        Products.Add(product);

        Added?.Invoke(this, new ProductAddingEventArgs(product));

        return product;
    }

    public Product Update(Product product)
    {
        Updating?.Invoke(this, new ProductUpdatingEventArgs(product));

        var currentProduct = Products.First(x => x.Id == product.Id);
        currentProduct.Name = product.Name;

        Updated?.Invoke(this, new ProductUpdatingEventArgs(product));

        return currentProduct;
    }
}