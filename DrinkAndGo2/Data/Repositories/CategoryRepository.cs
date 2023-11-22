using DrinkAndGo2.Data.Interfaces;
using DrinkAndGo2.Data.Models;

namespace DrinkAndGo2.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories;
    }
}
