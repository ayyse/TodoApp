using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TodoApp.Configuration;
using TodoApp.Web;

namespace TodoApp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TodoAppDbContextFactory : IDesignTimeDbContextFactory<TodoAppDbContext>
    {
        public TodoAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TodoAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TodoAppDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TodoAppConsts.ConnectionStringName));

            return new TodoAppDbContext(builder.Options);
        }
    }
}
