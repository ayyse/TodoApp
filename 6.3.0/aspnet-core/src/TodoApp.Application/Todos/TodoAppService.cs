using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Todos.Dto;

namespace TodoApp.Todos
{
    [AbpAuthorize]
    public class TodoAppService : AsyncCrudAppService<Todo, TodoDto, int>, ITodoAppService
    {
        private readonly IRepository<Todo, int> _todoRepository;
        private readonly IObjectMapper _mapper;
        public TodoAppService(IRepository<Todo, int> todoRepository, IObjectMapper mapper) : base(todoRepository)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public override async Task<TodoDto> CreateAsync(TodoDto input)
        {
            var todo = _mapper.Map<Todo>(input);
            var createdTodo = await _todoRepository.InsertAsync(todo);
            await CurrentUnitOfWork.SaveChangesAsync();
            return _mapper.Map<TodoDto>(createdTodo);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var deletedTodo = await _todoRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            await _todoRepository.DeleteAsync(deletedTodo);
        }

        public override async Task<TodoDto> UpdateAsync(TodoDto input)
        {
            var todo = _mapper.Map<Todo>(input);
            await _todoRepository.UpdateAsync(todo);
            await CurrentUnitOfWork.SaveChangesAsync();
            return _mapper.Map<TodoDto>(todo);
        }

        public async Task<List<TodoDto>> GetAllTodosAsync()
        {
            var todoList = await _todoRepository.GetAll().ToListAsync();
            return _mapper.Map<List<TodoDto>>(todoList);
        }

        public async Task<TodoDto> GetByIdAsync(int todoId)
        {
            var todo = await _todoRepository.FirstOrDefaultAsync(x => x.Id == todoId);
            return _mapper.Map<TodoDto>(todo);
        }

        public async Task<List<TodoDto>> GetByCategoryIdAsync(int categoryId)
        {
            var todosByCategory = await _todoRepository.GetAll().Where(x => x.CategoryId == categoryId).ToListAsync();
            return _mapper.Map<List<TodoDto>>(todosByCategory);
        }

    }
}
