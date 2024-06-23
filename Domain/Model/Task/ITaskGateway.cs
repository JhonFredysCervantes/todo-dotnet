namespace ToDo.Domain.Model;

public interface ITaskGateway
{
    Task CreateTask(Task task);
    Task? GetTask(Guid id);
    List<Task> GetTasks();
    Task UpdateTask(Task task);
    void DeleteTask(Guid id);
}