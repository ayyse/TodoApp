using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.EntityFrameworkCore
{
    public static class TodoAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TodoAppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TodoAppDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
