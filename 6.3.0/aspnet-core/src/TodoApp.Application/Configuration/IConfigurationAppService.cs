using System.Threading.Tasks;
using TodoApp.Configuration.Dto;

namespace TodoApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
