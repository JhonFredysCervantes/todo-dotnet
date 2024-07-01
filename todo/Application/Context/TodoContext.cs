using Microsoft.EntityFrameworkCore;
using ToDo.Infrastructure.Adapters.Persistence;

namespace ToDo.Application.Context;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>(
            entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.Title);
                entity.Property(e => e.Description);
                entity.Property(e => e.DueDate);
                entity.Property(e => e.IsCompleted);
            });
        modelBuilder.Entity<CategoryEntity>(
            entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id);
                entity.Property(e => e.Name);
            }
        );
    }
}