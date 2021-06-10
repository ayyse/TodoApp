using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Categories.Dto;

namespace TodoApp.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, int>
    {
        Task<CategoryDto> GetByCategoryId(int categoryId);
    }
}
