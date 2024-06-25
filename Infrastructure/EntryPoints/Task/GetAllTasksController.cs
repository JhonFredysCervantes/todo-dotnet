using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.UseCases;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Infrastructure.EntryPoints;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class GetAllTasksController : ControllerBase
{
    private readonly GetAllTask _getAllTask;

    public GetAllTasksController(GetAllTask getAllTask)
    {
        _getAllTask = getAllTask;
    }

    [HttpGet("/api/v1/tasks")]
    public ActionResult<List<Task>> GetAllTasks()
    {
        var tasks = _getAllTask.Execute();
        return Ok(tasks);
    }
}