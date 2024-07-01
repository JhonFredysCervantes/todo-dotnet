using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.UseCases;

namespace ToDo.Infrastructure.EntryPoints;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class GetTaskController : ControllerBase
{
    private readonly GetTask _getTask;

    public GetTaskController(GetTask getTask)
    {
        _getTask = getTask;
    }

    [HttpGet("api/v1/tasks/{id}")]
    public IActionResult GetTasks(Guid id)
    {
        return Ok(_getTask.Execute(id));
    }
}