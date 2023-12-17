using System.Reflection;

namespace DotNetWorkspace.Extensions;

/// <summary>
///     Provides extension methods for <see cref="Type" />.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    ///     Determines whether the current <see cref="Type" /> can be assigned to a variable of the specified
    ///     <paramref name="targetType" />.
    /// </summary>
    /// <remarks>
    ///     The specified <paramref name="targetType" /> can be a generic type.
    /// </remarks>
    /// <param name="type"></param>
    /// <param name="targetType">The type to compare with the current type.</param>
    /// <returns>
    ///     <see langword="true" /> if the current type can be assigned to the specified <paramref name="targetType" />,
    ///     otherwise <see langword="false" />.
    /// </returns>
    public static bool IsAssignableToGenericType(this Type type, Type targetType) =>
        type.IsAssignableTo(targetType) ||
        (type.IsGenericType && type.GetGenericTypeDefinition() == targetType) ||
        type.GetInterfaces().Where(x => x.IsGenericType).Any(x => x.GetGenericTypeDefinition() == targetType) ||
        (type.BaseType is not null && type.BaseType.IsAssignableToGenericType(targetType));

    /// <summary>
    ///     Searches for the public property with the specified <paramref name="propertyType" />.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyType">The type of the public property to get.</param>
    /// <returns>
    ///     An object representing the <b>first</b> public property with the specified type, if found;
    ///     otherwise, <see langword="null" />.
    /// </returns>
    public static PropertyInfo? GetProperty(this Type type, Type propertyType) =>
        type.GetProperties().FirstOrDefault(x => x.PropertyType == propertyType);

    /// <summary>
    ///     Searches concrete types that implement the current <see cref="Type" />
    ///     in the <see cref="Assembly" /> of the method that invoked the currently executing method.
    /// </summary>
    /// <inheritdoc cref="GetConcretes(Type, Assembly[])" />
    public static Type[] GetConcretes(this Type type) =>
        GetConcretes(type, Assembly.GetCallingAssembly());

    /// <summary>
    ///     Searches concrete types that implement the current <see cref="Type" />
    ///     in each <see cref="Assembly" /> of the <paramref name="assemblies" /> array.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="assemblies">The assemblies to scan.</param>
    /// <returns>
    ///     An array of <see cref="Type" /> objects
    ///     representing all concrete elements that implement the current <paramref name="type" />.
    /// </returns>
    public static Type[] GetConcretes(this Type type, params Assembly[] assemblies) =>
        assemblies.Distinct().SelectMany(x => x.GetTypes())
            .Where(x => x is { IsAbstract: false } && x.IsAssignableTo(type)).ToArray();

    /// <summary>
    ///     Retrieves a custom attribute of the current <see cref="Type" />.
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="type"></param>
    /// <returns>
    ///     A reference to the single custom attribute of type <typeparamref name="TAttribute" /> that is applied to
    ///     current <see cref="Type" />, or null if there is no such attribute.
    /// </returns>
    public static TAttribute? GetCustomAttribute<TAttribute>(this Type type)
        where TAttribute : Attribute
    {
        return Attribute.GetCustomAttribute(type, typeof(TAttribute)) as TAttribute;
    }

    /// <summary>
    ///     Retrieves an array of the custom attributes applied to the current <see cref="Type" />.
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="type"></param>
    /// <returns>
    ///     An <see cref="Attribute" /> array that contains the custom attributes applied
    ///     to the current <see cref="Type" />.
    /// </returns>
    public static TAttribute[] GetCustomAttributes<TAttribute>(this Type type)
        where TAttribute : Attribute
    {
        return Attribute.GetCustomAttributes(type, typeof(TAttribute)).OfType<TAttribute>().ToArray();
    }
}