
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess
{

    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task AddCategory(Category Category);
        Task UpdateCategory(Category Category);
        Task DeleteCategory(int id);
    }

    public class CategorygerRepository : ICategoryRepository
    {
        private readonly DbContextConnector _dbContext;

        public CategorygerRepository(DbContextConnector dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task AddCategory(Category Category)
        {
            try
            {
                _dbContext.Categories.Add(Category);
                await _dbContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {

            }
        }

        public async Task UpdateCategory(Category Category)
        {
            _dbContext.Entry(Category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var Category = await _dbContext.Categories.FindAsync(id);
            if (Category != null)
            {
                _dbContext.Categories.Remove(Category);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}