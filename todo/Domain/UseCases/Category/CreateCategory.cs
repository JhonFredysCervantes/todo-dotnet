using ToDo.Domain.Model;

namespace ToDo.Domain.UseCases;
public class CreateCategory
{
    private readonly ICategoryGateway _categoryGateway;

    public CreateCategory(ICategoryGateway categoryGateway)
    {
        _categoryGateway = categoryGateway;
    }

    public Category Execute(Category category)
    {
        return _categoryGateway.CreateCategory(category);
    }
}