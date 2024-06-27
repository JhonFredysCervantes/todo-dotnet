using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.UseCases;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Infrastructure.EntryPoints;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TaskController : ControllerBase
{
    private readonly CreateTask _createTask;
    private ILogger<TaskController> _logger;

    public TaskController(CreateTask createTask, ILogger<TaskController> logger)
    {
        _createTask = createTask;
        _logger = logger;
    }

    [HttpPost("api/v1/tasks")]
    public ActionResult<Task> CreateTask(Task task)
    {
        _logger.LogInformation("Creating task: {Task}", task);
        var createdTask = _createTask.Execute(task);
        _logger.LogInformation("Task created: {Task}", createdTask);
        return Ok(createdTask);
    }

}
