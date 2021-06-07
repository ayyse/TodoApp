using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TodoApp.Authorization;

namespace TodoApp
{
    [DependsOn(
        typeof(TodoAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TodoAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TodoAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TodoAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
