using DotNetWorkspace.EFCore.Model.Common;

namespace DotNetWorkspace.EFCore.Model
{
    public class Person : IOwnedEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
