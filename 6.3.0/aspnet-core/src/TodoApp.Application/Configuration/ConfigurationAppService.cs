using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TodoApp.Configuration.Dto;

namespace TodoApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TodoAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
