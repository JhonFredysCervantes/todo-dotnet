namespace ToDo.Domain.Model;
public class Task
{
    private Guid id;
    public Guid Id { get { return id; } set { id = value; } }
    private string title;
    public string Title { get { return title; } set { title = value; } }
    private string description;
    public string Description { get { return description; } set { description = value; } }
    private DateTime dueDate;
    public DateTime DueDate { get { return dueDate; } set { dueDate = value; } }
    private bool isCompleted;
    public bool IsCompleted { get { return isCompleted; } set { isCompleted = value; } }

    public override string ToString()
    {
        return $"{{\"id\": \"{Id}\", \"title\": \"{Title}\", \"description\": \"{Description}\", \"dueDate\": \"{DueDate}\", \"isCompleted\": \"{IsCompleted}\"}}";
    }
}
