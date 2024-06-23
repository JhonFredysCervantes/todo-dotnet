using ToDo.Domain.Model.Exceptions;

namespace ToDo.Domain.Model.Exception;

public class TaskNotFoundException : BaseException
{
    public TaskNotFoundException(string IdTask)
    : base("TaskNotFoundException", "TD-T-001", $"Task with id {IdTask} not found")
    {
    }
}