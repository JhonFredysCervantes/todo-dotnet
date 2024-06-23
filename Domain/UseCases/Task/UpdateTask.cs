using ToDo.Domain.Model;
using ToDo.Domain.Model.Exception;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Domain.UseCases;

public class UpdateTask
{
    private readonly ITaskGateway _taskGateway;

    public UpdateTask(ITaskGateway taskGateway)
    {
        _taskGateway = taskGateway;
    }

    public Task Execute(Guid id, Task task)
    {
        var taskToUpdate = _taskGateway.GetTask(id);
        if (taskToUpdate == null)
        {
            throw new TaskNotFoundException(id.ToString());
        }
        return _taskGateway.UpdateTask(task);
    }
}