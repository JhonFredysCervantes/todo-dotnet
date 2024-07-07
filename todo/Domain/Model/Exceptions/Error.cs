namespace ToDo.Domain.Model.Exceptions;

public class Error
{
    public String Name { get; }
    public String Code { get; }
    public String Message { get; }

    public Error (string Name, string Code, string Message)
    {
        this.Name = Name;
        this.Code = Code;
        this.Message = Message;
    }
}