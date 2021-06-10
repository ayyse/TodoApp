using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TodoApp.Authorization.Roles;
using TodoApp.Authorization.Users;
using TodoApp.MultiTenancy;
using TodoApp.Models;

namespace TodoApp.EntityFrameworkCore
{
    public class TodoAppDbContext : AbpZeroDbContext<Tenant, Role, User, TodoAppDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
