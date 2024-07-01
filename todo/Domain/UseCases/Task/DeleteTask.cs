using ToDo.Domain.Model;
using ToDo.Domain.Model.Exception;

namespace ToDo.Domain.UseCases;

public class DeleteTask
{
    private readonly ITaskGateway _taskGateway;

    public DeleteTask(ITaskGateway taskGateway)
    {
        _taskGateway = taskGateway;
    }

    public void Execute(Guid id)
    {
        var task = _taskGateway.GetTask(id);

        if (task == null)
        {
            throw new TaskNotFoundException(id.ToString());
        }

        _taskGateway.DeleteTask(id);
    }
}