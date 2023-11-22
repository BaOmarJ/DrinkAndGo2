using DrinkAndGo2.Data.Models;

namespace DrinkAndGo2.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}