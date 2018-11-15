using CMS.Core.Core;

namespace CMS.Core.Helpers
{
    public static class RoleHelper
    {
        public static bool CheckRole(string name)
        {
            return UserCredentials.Roles.Find(role => role.Name.Equals(name)) != null;
        }

        public static bool CheckRoles(string[] names)
        {
            foreach (var name in names)
            {
                if (CheckRole(name)) return true;
            }
            return false;
        }
    }
}
