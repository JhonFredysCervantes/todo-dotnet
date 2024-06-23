namespace ToDo.Domain.Model.Exceptions;

public class BaseException : ApplicationException
{
    public Error Error { get; set; }

    public BaseException(string Name, string Code, string Message) : base(Message)
    {
        Error = new Error(Name, Code, Message);
    }
}