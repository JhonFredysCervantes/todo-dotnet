using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.UseCases;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.infrastructure.entryPoints;

public class UpdateTaskController : ControllerBase
{
    private readonly UpdateTask _updateTask;

    public UpdateTaskController(UpdateTask updateTask)
    {
        _updateTask = updateTask;
    }

    [HttpPut("api/v1/tasks/{id}")]
    public ActionResult<Task> UpdateTask(Guid id, Task task)
    {
        var updatedTask = _updateTask.Execute(id, task);
        return Ok(updatedTask);
    }
}