﻿using System.Threading.Tasks;
using Abp.Application.Services;
using TodoApp.Authorization.Accounts.Dto;

namespace TodoApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
