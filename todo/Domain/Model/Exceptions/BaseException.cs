namespace ToDo.Domain.Model.Exceptions;

public class BaseException : ApplicationException
{
    public Error Error { get;}

    public BaseException(string Name, string Code, string Message) : base(Message)
    {
        this.Error = new Error(Name, Code, Message);
    }
}