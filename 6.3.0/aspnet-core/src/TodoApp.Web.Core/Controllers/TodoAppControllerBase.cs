using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TodoApp.Controllers
{
    public abstract class TodoAppControllerBase: AbpController
    {
        protected TodoAppControllerBase()
        {
            LocalizationSourceName = TodoAppConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
