using ToDo.Application.Context;
using ToDo.Domain.Model;
using ToDo.Domain.UseCases;
using ToDo.Infrastructure.Adapters.Gateway;
using ToDO.Infrastructure.EntryPoints.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<TodoContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddScoped<ICategoryGateway, CategoryGatewayImp>();
builder.Services.AddScoped<ITaskGateway, TaskGatewayImp>();

builder.Services.AddScoped<CreateTask>();
builder.Services.AddScoped<DeleteTask>();
builder.Services.AddScoped<GetTask>();
builder.Services.AddScoped<UpdateTask>();
builder.Services.AddScoped<GetAllTask>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseMiddleware<HeadersMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.UseHttpsRedirection();
app.Run();