namespace ToDoTest.Domain.UseCase.Task;

using Moq;
using ToDo.Domain.UseCases;
using ToDo.Domain.Model;
using ToDoTest.Domain.Model.Task;


public class GetAllTaskTests
{
    private readonly GetAllTask getAllTask;
    private readonly Mock<ITaskGateway> taskGatewayMock;

    public GetAllTaskTests()
    {
        taskGatewayMock = new Mock<ITaskGateway>();
        getAllTask = new GetAllTask(taskGatewayMock.Object);
    }

    [Fact(Skip = "Example of how to skip a test")]
    void GetAllTask_Successfully()
    {
        var validTask = TaskMother.ValidTask();

        taskGatewayMock.Setup(gateway => gateway.GetTasks())
        .Returns(() => new List<Task> { validTask });

        var result = getAllTask.Execute();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Equal(validTask.Title, result.First().Title);
    }
}