using ToDo.Domain.Model;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Domain.UseCases;

public class GetAllTask
{
    private readonly ITaskGateway _taskGateway;

    public GetAllTask(ITaskGateway taskGateway)
    {
        _taskGateway = taskGateway;
    }

    public List<Task> Execute()
    {
        return _taskGateway.GetTasks();
    }
}