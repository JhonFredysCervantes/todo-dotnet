using ToDo.Application.Context;
using ToDo.Domain.Model;

namespace ToDo.Infrastructure.Adapters.Gateway;

public class CategoryGatewayImp : ICategoryGateway
{
    private readonly TodoContext _context;

    public CategoryGatewayImp(TodoContext context)
    {
        _context = context;
    }
    
    public Category CreateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Domain.Model.Task DeleteCategory(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetCategories()
    {
        throw new NotImplementedException();
    }

    public Category GetCategory(Guid id)
    {
        throw new NotImplementedException();
    }

    public Category UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }
}