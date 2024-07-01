namespace ToDoTest.Domain.Model.Task;

using ToDo.Domain.Model;
using Task = ToDo.Domain.Model.Task;

public class TaskMother
{
    public static Task ValidTask()
    {
        return new Task();
    }
}