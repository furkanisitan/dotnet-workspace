using System.Reflection;

namespace DotNetWorkspace.ExtensionMethods;

/// <summary>
///     Extension methods for <see cref="Type" />.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    ///     Determines whether the current type can be assigned to a variable of the specified <paramref name="targetType" />.
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
    public static bool IsAssignableToGenericType(this Type type, Type targetType)
    {
        return type.IsAssignableTo(targetType) ||
               (type.IsGenericType && type.GetGenericTypeDefinition() == targetType) ||
               type.GetInterfaces().Where(x => x.IsGenericType).Any(x => x.GetGenericTypeDefinition() == targetType) ||
               (type.BaseType is not null && type.BaseType.IsAssignableToGenericType(targetType));
    }

    /// <summary>
    ///     Searches for the public property with the specified <paramref name="propertyType" />.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="propertyType">The type of the public property to get.</param>
    /// <returns>
    ///     An object representing the <b>first</b> public property with the specified type, if found;
    ///     otherwise, <see langword="null" />.
    /// </returns>
    public static PropertyInfo? GetProperty(this Type type, Type propertyType)
    {
        return type.GetProperties().FirstOrDefault(x => x.PropertyType == propertyType);
    }
}