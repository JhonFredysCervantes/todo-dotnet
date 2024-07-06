using ToDo.Domain.Model;
using ToDo.Domain.Model.Exception.Task;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Domain.UseCases;

public class CreateTask
{
    private readonly ITaskGateway _taskGateway;

    public CreateTask(ITaskGateway taskGateway)
    {
        _taskGateway = taskGateway;
    }

    public Task Execute(Task task)
    {
        if (task.Id == Guid.Empty)
        {
            task.Id = Guid.NewGuid();
        }
        else if (_taskGateway.GetTask(task.Id) != null)
        {
            throw new TaskAlreadyExistsException(task.Id.ToString());
        }
        return _taskGateway.CreateTask(task);
    }
}