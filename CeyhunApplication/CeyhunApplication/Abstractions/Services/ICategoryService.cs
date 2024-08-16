using CeyhunApplication.Models;

namespace CeyhunApplication.Abstractions.Services;

public interface ICategoryService
{
    Category GetCategoryById(int id);

    List<Category> GetAll(string? expression);
}
