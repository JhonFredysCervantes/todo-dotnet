using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.UseCases;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Infrastructure.EntryPoints;

public class TaskController : ControllerBase
{
    private readonly CreateTask _createTask;

    public TaskController(CreateTask createTask)
    {
        _createTask = createTask;
    }

    [HttpPost("api/v1/tasks")]
    public ActionResult<Task> CreateTask(Task task)
    {
        var createdTask = _createTask.Execute(task);
        return Ok(createdTask);
    }

}
