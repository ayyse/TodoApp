using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Categories;
using TodoApp.Categories.Dto;
using TodoApp.Models;

namespace AngularBoilerplate.Categories
{
    [AbpAuthorize]
    public class CatogoryAppService : AsyncCrudAppService<Category, CategoryDto, int>, ICategoryAppService
    {
        private readonly IRepository<Category, int> _categoryRepository;
        private readonly IObjectMapper _mapper;

        public CatogoryAppService(IRepository<Category, int> categoryRespoistory, IObjectMapper mapper) : base(categoryRespoistory)
        {
            _categoryRepository = categoryRespoistory;
            _mapper = mapper;
        }

        public override async Task<CategoryDto> CreateAsync(CategoryDto input)
        {
            var category = _mapper.Map<Category>(input);
            var createdCategory = await _categoryRepository.InsertAsync(category);
            await CurrentUnitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(createdCategory);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var deletedCategory = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            await _categoryRepository.DeleteAsync(deletedCategory);
        }

        public override async Task<CategoryDto> UpdateAsync(CategoryDto input)
        {
            var category = _mapper.Map<Category>(input);
            await _categoryRepository.UpdateAsync(category);
            await CurrentUnitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categoryList = await _categoryRepository.GetAll().ToListAsync();
            return _mapper.Map<List<CategoryDto>>(categoryList);
        }

        public async Task<CategoryDto> GetByCategoryId(int categoryId)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == categoryId);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
