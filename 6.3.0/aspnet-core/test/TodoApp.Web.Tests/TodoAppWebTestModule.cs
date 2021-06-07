using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TodoApp.EntityFrameworkCore;
using TodoApp.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TodoApp.Web.Tests
{
    [DependsOn(
        typeof(TodoAppWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TodoAppWebTestModule : AbpModule
    {
        public TodoAppWebTestModule(TodoAppEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TodoAppWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TodoAppWebMvcModule).Assembly);
        }
    }
}