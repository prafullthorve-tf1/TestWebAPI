using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestWebAPI.Data;
using TestWebAPI.Models.Domain;
using TestWebAPI.Models.DTO;
using TestWebAPI.Repositories.Interface;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult>CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await _categoryRepository.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var response = categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            });

            return Ok(response);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryDto request)
        {
            var category = new Category
            {
                Id = request.Id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            var updatedCategory = await _categoryRepository.UpdateAsync(category);

            if (updatedCategory == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = updatedCategory.Id,
                Name = updatedCategory.Name,
                UrlHandle = updatedCategory.UrlHandle
            };

            return Ok(response);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var deletedCategory = await _categoryRepository.DeleteAsync(id);

            if (deletedCategory == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = deletedCategory.Id,
                Name = deletedCategory.Name,
                UrlHandle = deletedCategory.UrlHandle
            };

            return Ok(response);
        }

        [HttpGet("GetCategoryByName/{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var category = await _categoryRepository.GetByNameAsync(name);

            if (category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        

        
        

    }
}
