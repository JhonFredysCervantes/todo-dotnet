namespace ToDoTest.Domain.UseCase.Task;

using ToDo.Domain.UseCases;
using ToDo.Domain.Model;
using ToDoTest.Domain.Model.Task;
using Moq;

public class CreateTaskTests
{
    private readonly CreateTask createTask;
    private readonly Mock<ITaskGateway> taskGatewayMock;

    public CreateTaskTests()
    {
        taskGatewayMock = new Mock<ITaskGateway>();
        createTask = new CreateTask(taskGatewayMock.Object);
    }

    [Fact]
    void CreateTaskSuccessfully()
    {
        var validTask = TaskMother.ValidTask();

        taskGatewayMock.Setup(gateway => gateway.GetTask(It.IsAny<Guid>()))
        .Returns(() => null);
        taskGatewayMock.Setup(gateway => gateway.CreateTask(It.IsAny<Task>()))
        .Returns(() => validTask);

        var result = createTask.Execute(validTask);

        Assert.Equal(validTask.Title, result.Title);
    }
}