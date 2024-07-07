namespace ToDoTest.Domain.UseCase.Task;

using Moq;
using ToDo.Domain.UseCases;
using ToDo.Domain.Model;
using ToDoTest.Domain.Model.Task;
using ToDo.Domain.Model.Exception;

public class GetTaskTests
{
    private readonly GetTask getTask;
    private readonly Mock<ITaskGateway> taskGatewayMock;

    public GetTaskTests()
    {
        taskGatewayMock = new Mock<ITaskGateway>();
        getTask = new GetTask(taskGatewayMock.Object);
    }

    // Example of how parameterized tests work
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    [InlineData("00000000-0000-0000-0000-000000000001")]
    void GetTask_Successfully(string id)
    {
        var validTask = TaskMother.ValidTask();
        var guidId = Guid.Parse(id);

        taskGatewayMock.Setup(gateway => gateway.GetTask(It.IsAny<Guid>()))
        .Returns(() => validTask);

        var result = getTask.Execute(validTask.Id);

        Assert.Equal(validTask.Title, result.Title);
    }

    [Fact]
    void GetTask_WithInvalidID_Fails()
    {
        var validTask = TaskMother.ValidTask();

        taskGatewayMock.Setup(gateway => gateway.GetTask(It.IsAny<Guid>()))
        .Returns(() => null);

        var exception = Assert.Throws<TaskNotFoundException>(() => getTask.Execute(validTask.Id));
        Console.WriteLine(exception.Message);
    }
}