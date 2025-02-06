using Microsoft.EntityFrameworkCore;
using TestWebAPI.Data;
using TestWebAPI.Models.Domain;
using TestWebAPI.Repositories.Interface;

namespace TestWebAPI.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Existing methods...

        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            dbContext.Categories.Update(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteAsync(Guid id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();

            return category;
        }
    }
}
