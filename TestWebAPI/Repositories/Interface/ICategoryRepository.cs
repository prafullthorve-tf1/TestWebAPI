using TestWebAPI.Models.Domain;

namespace TestWebAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        // method to get category by id
        Task<Category> GetByIdAsync(Guid id);

        Task<Category> GetByNameAsync(string name);

        // method to get all categories
        Task<IEnumerable<Category>> GetAllAsync();

        // method to update category
        Task<Category> UpdateAsync(Category category);

        Task<Category> DeleteAsync(Guid id);

    }
}
