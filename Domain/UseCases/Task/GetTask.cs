using ToDo.Domain.Model;
using ToDo.Domain.Model.Exception;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Domain.UseCases;

public class GetTask
{
    private readonly ITaskGateway _taskGateway;

    public GetTask(ITaskGateway taskGateway)
    {
        _taskGateway = taskGateway;
    }

    public Task Execute(Guid id)
    {
        var task = _taskGateway.GetTask(id);

        if (task == null)
        {
            throw new TaskNotFoundException(id.ToString());
        }
        
        return task;
    }
}