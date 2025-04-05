using DotNetWorkspace.EventHandling;

var productRepository = new ProductRepository();
productRepository.Adding += OnAdding;
productRepository.Added += OnAdded;
productRepository.Updating += OnUpdating;
productRepository.Updated += OnUpdated;

var product = new Product
{
    Name = "Product 1"
};

product = productRepository.Add(product);
Console.WriteLine(product.ToString());

product.Name = "Updated Product";
product = productRepository.Update(product);
Console.WriteLine(product.ToString());

Console.ReadLine();
return;

static void OnUpdated(object sender, ProductUpdatingEventArgs e)
{
    Console.WriteLine("Product updated.");
}

static void OnUpdating(object sender, ProductUpdatingEventArgs e)
{
    e.Product.UpdatedDate = DateTime.Now;
}

static void OnAdded(object sender, ProductAddingEventArgs e)
{
    Console.WriteLine("Product added.");
}

static void OnAdding(object? sender, ProductAddingEventArgs e)
{
    e.Product.CreatedDate = DateTime.Now;
}