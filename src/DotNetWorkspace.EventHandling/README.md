# Event Handling in C#

This repository demonstrates different approaches to defining and using events in C#, with examples of both recommended and not recommended practices.

## 📌 Overview

The project focuses on how events can be declared and invoked in a C# application using both:

- **.NET Standard-style events** (`EventHandler<T>`)
- **.NET Core-style events** (`Action<object, T>`)

It also includes examples of custom delegate-based event declarations, which are **not recommended** according to modern .NET event design guidelines.

## ✅ Good Practices

```csharp
public event EventHandler<ProductAddingEventArgs>? Adding;
public event Action<object, ProductAddingEventArgs>? Added;
```

These follow recommended patterns and are consistent with modern .NET conventions.

## 🚫 Bad Practices

```csharp
public delegate void ProductUpdatingEventHandler(object sender, ProductUpdatingEventArgs e);
public event ProductUpdatingEventHandler? Updating;
public event ProductUpdatingEventHandler? Updated;
```

The use of custom delegate types for events is discouraged instead of standard types like `EventHandler<T>` or `Action<object, T>` for consistency and maintainability.

## 💡 Usage

Event handlers are attached to lifecycle events of a `ProductRepository`. Events are raised during `Add` and `Update` operations.

Example handlers:

```csharp
static void OnAdding(object? sender, ProductAddingEventArgs e)
{
    e.Product.CreatedDate = DateTime.Now;
}

static void OnUpdating(object sender, ProductUpdatingEventArgs e)
{
    e.Product.UpdatedDate = DateTime.Now;
}
```

## 📖 References

- [Event Design Guidelines](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/event)
- [C# Coding Conventions – Delegates](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions#delegates)
- [Event Naming Conventions](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members#names-of-events)
- [Modern .NET Core Event Pattern](https://learn.microsoft.com/en-us/dotnet/csharp/modern-events)
