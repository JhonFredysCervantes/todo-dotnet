namespace ToDo.Domain.Model.Exceptions;

public class Error
{
    public String Name { get; set; }
    public String Code { get; set; }
    public String Message { get; set; }

    public Error (string Name, string Code, string Message)
    {
        Name = Name;
        Code = Code;
        Message = Message;
    }
}