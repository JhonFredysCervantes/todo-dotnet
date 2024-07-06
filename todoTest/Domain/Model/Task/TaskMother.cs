namespace ToDoTest.Domain.Model.Task;

using ToDo.Domain.Model;
using Task = ToDo.Domain.Model.Task;

public class TaskMother
{
    public static Task ValidTask()
    {
        return new Task()
        {
            Id = new Guid("2f8f441f-9efd-4e1e-8705-e450e04ab95a"),
            Title = "Test Task",
            Description = "Test description",
            DueDate = new DateTime(),
            IsCompleted = false
        };
    }

    public static Task TaskWithoutID()
    {
        return new Task()
        {
            Title = "Test Task",
            Description = "Test description",
            DueDate = new DateTime(),
            IsCompleted = false
        };
    }
}