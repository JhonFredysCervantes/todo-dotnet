using ToDo.Application.Context;
using ToDo.Domain.Model;
using ToDo.Infrastructure.Adapters.Persistence;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Infrastructure.Adapters.Gateway;

public class TaskGatewayImp : ITaskGateway
{
    private readonly TodoContext _context;

    public TaskGatewayImp(TodoContext context)
    {
        _context = context;
    }

    public Task CreateTask(Task task)
    {
        var taskEntity = TaskEntity.toEntity(task);
        _context.Tasks.Add(taskEntity);
        _context.SaveChanges();
        return task;
    }

    public void DeleteTask(Guid id)
    {
        var task = _context.Tasks.Find(id);
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }

    public List<Task> GetTasks()
    {
        var tasksEntity = _context.Tasks.ToList();

        var tasks = new List<Task>();
        foreach (var taskEntity in tasksEntity)
        {
            tasks.Add(TaskEntity.toDomain(taskEntity));
        }

        return tasks;
    }

    public Task? GetTask(Guid id)
    {
        var taskEntity = _context.Tasks.Find(id);

        if (taskEntity == null)
        {
            return null;
        }
        return TaskEntity.toDomain(taskEntity);
    }

    public Task UpdateTask(Task task)
    {
        var taskEntity = _context.Tasks.Find(task.Id);
        taskEntity.Title = task.Title;
        taskEntity.Description = task.Description;
        taskEntity.IsCompleted = task.IsCompleted;
        _context.Tasks.Update(taskEntity);
        _context.SaveChanges();
        return task;
    }
}