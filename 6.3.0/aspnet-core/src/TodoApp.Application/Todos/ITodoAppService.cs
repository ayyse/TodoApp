using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Todos.Dto;

namespace TodoApp.Todos
{
    public interface ITodoAppService : IAsyncCrudAppService<TodoDto, int>
    {
        Task<TodoDto> GetByIdAsync(int todoId);

        Task<List<TodoDto>> GetByCategoryIdAsync(int categoryId);
    }
}
