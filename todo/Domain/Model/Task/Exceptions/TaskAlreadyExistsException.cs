using ToDo.Domain.Model.Exceptions;

namespace ToDo.Domain.Model.Exception;

public class TaskAlreadyExistsException : BaseException
{
    public TaskAlreadyExistsException(string id)
    : base("TaskAlreadyExistsException", "TD-T-002", $"Task with id {id} already exists.")
    {
    }
}