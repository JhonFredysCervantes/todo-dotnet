namespace ToDoTest.Domain.UseCase.Task;

using ToDo.Domain.UseCases;
using ToDo.Domain.Model;
using ToDoTest.Domain.Model.Task;
using Moq;
using ToDo.Domain.Model.Exception.Task;

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
    void CreateTask_WithID_Successfully()
    {
        var validTask = TaskMother.ValidTask();

        taskGatewayMock.Setup(gateway => gateway.GetTask(It.IsAny<Guid>()))
        .Returns(() => null);
        taskGatewayMock.Setup(gateway => gateway.CreateTask(It.IsAny<Task>()))
        .Returns(() => validTask);

        var result = createTask.Execute(validTask);

        Assert.Equal(validTask.Title, result.Title);
    }

    [Fact]
    void CreateTask_WithoutID_Successfully()
    {
        var validTask = TaskMother.TaskWithoutID();

        taskGatewayMock.Setup(gateway => gateway.GetTask(It.IsAny<Guid>()))
        .Returns(() => null);
        taskGatewayMock.Setup(gateway => gateway.CreateTask(It.IsAny<Task>()))
        .Returns(() => validTask);

        var result = createTask.Execute(validTask);

        Assert.Equal(validTask.Title, result.Title);
    }

    [Fact]
    void CreateTask_WithExistingID_Fails()
    {
        var validTask = TaskMother.ValidTask();

        taskGatewayMock.Setup(gateway => gateway.GetTask(It.IsAny<Guid>()))
        .Returns(() => validTask);

        var exception = Assert.Throws<TaskAlreadyExistsException>(() => createTask.Execute(validTask));

        Assert.Equal("TaskAlreadyExistsException", exception.Error.Name);
        Assert.Equal("TD-T-002", exception.Error.Code);
    }
}