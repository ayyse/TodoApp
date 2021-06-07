using System.Threading.Tasks;
using Abp.Application.Services;
using TodoApp.Sessions.Dto;

namespace TodoApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
