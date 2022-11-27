namespace DotNetWorkspace.ExtensionMethods
{
    /// <summary>
    /// Extension methods for <see cref="Type"/>.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the current type can be assigned to a variable of the specified <paramref name="targetType"/>. <br/>
        /// The specified <paramref name="targetType"/> can be a generic type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="targetType">The type to compare with the current type.</param>
        /// <returns><see langword="true"/> if the current type can be assigned to the specified <paramref name="targetType"/>, otherwise <see langword="false"/>.</returns>
        public static bool IsAssignableToGenericType(this Type type, Type? targetType)
        {
            if (targetType is null)
                return false;

            return type.IsAssignableTo(targetType) ||
                   type.IsGenericType && type.GetGenericTypeDefinition() == targetType ||
                   type.GetInterfaces().Where(x => x.IsGenericType).Any(x => x.GetGenericTypeDefinition() == targetType) ||
                   type.BaseType is not null && type.BaseType.IsAssignableToGenericType(targetType);
        }

    }
}
