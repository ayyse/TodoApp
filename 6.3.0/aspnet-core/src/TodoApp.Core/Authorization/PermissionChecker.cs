using Abp.Authorization;
using TodoApp.Authorization.Roles;
using TodoApp.Authorization.Users;

namespace TodoApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
