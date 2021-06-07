using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TodoApp.Configuration;

namespace TodoApp.Web.Host.Startup
{
    [DependsOn(
       typeof(TodoAppWebCoreModule))]
    public class TodoAppWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TodoAppWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TodoAppWebHostModule).GetAssembly());
        }
    }
}
