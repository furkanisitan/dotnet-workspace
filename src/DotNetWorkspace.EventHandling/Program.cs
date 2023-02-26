// Event Design
// @see https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/event

// C# Coding Conventions
// @see https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions#delegates

// Event Naming Convention
// @see https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members?redirectedfrom=MSDN#names-of-events

// The Updated .NET Core Event Pattern
// @see https://learn.microsoft.com/en-us/dotnet/csharp/modern-events


using DotNetWorkspace.EventHandling;

static void OnAdding(object? sender, ProductAddingEventArgs e)
{
    e.Product.CreatedDate = DateTime.Now;
}

static void OnAdded(object sender, ProductAddingEventArgs e)
{
    Console.WriteLine("Product added.");
}

static void OnUpdating(object sender, ProductUpdatingEventArgs e)
{
    e.Product.UpdatedDate = DateTime.Now;
}

static void OnUpdated(object sender, ProductUpdatingEventArgs e)
{
    Console.WriteLine("Product updated.");
}

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