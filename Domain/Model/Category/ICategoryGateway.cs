namespace ToDo.Domain.Model;

public interface ICategoryGateway
{
    Category CreateCategory(Category category);
    Category GetCategory(Guid id);
    IEnumerable<Category> GetCategories();
    Category UpdateCategory(Category category);
    Task DeleteCategory(Guid id);
}