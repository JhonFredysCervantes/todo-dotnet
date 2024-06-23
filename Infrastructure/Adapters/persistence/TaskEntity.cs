using ToDo.Domain.Model;
using Task = ToDo.Domain.Model.Task;

namespace ToDo.Infrastructure.Adapters.Persistence;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }


    public static TaskEntity toEntity(Task task)
    {
        return new TaskEntity
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }

    public static Task toDomain(TaskEntity taskEntity)
    {
        return new Task
        {
            Id = taskEntity.Id,
            Title = taskEntity.Title,
            Description = taskEntity.Description,
            DueDate = taskEntity.DueDate,
            IsCompleted = taskEntity.IsCompleted
        };
    }
}
