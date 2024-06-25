using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.UseCases;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Infrastructure.EntryPoints;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class DeleteTaskController : ControllerBase
{
    private readonly DeleteTask _deleteTask;

    public DeleteTaskController(DeleteTask deleteTask)
    {
        _deleteTask = deleteTask;
    }

    [HttpDelete("api/v1/tasks{id}")]
    public ActionResult<Task> DeleteTask(Guid id)
    {
        _deleteTask.Execute(id);
        return Ok();
    }
}