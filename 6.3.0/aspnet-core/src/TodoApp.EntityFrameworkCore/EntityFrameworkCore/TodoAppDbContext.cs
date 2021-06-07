using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TodoApp.Authorization.Roles;
using TodoApp.Authorization.Users;
using TodoApp.MultiTenancy;

namespace TodoApp.EntityFrameworkCore
{
    public class TodoAppDbContext : AbpZeroDbContext<Tenant, Role, User, TodoAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options)
            : base(options)
        {
        }
    }
}
