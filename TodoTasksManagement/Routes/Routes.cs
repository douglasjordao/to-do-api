using Entities;
using Microsoft.AspNetCore.Mvc;
using TodoTasksManagement.Repository;

namespace TodoTasksManagement.Routes
{
    public static class Routes
    {
        public static void RegisterTodoTasksRoutes(this WebApplication app)
        {
            app.MapGet("api/tasks", async ([FromServices] IRepository repository, [FromQuery] int page, [FromQuery] int pageSize) =>
            {
                return Results.Ok(await repository.GetPaginatedResults(page, pageSize));
            });

            app.MapPost("api/task", async ([FromServices] IRepository repository, [FromBody] TodoTask task) =>
            {
                try
                {
                    var newTask = await repository.CreateTask(task);

                    return Results.Created(string.Concat("tasks/", newTask.Id), newTask);
                }
                catch (Exceptions.ValidationException ex)
                {
                    return Results.BadRequest(ex.Errors);
                }
            });

            app.MapPut("api/task/{id}", async ([FromServices] IRepository repository, [FromBody] TodoTask task, [FromRoute] string id) =>
            {
                try
                {
                    await repository.UpdateTask(task, id);

                    return Results.NoContent();
                }
                catch (Exceptions.RecordNotFoundException)
                {
                    return Results.NotFound();
                }
                catch (Exceptions.ValidationException ex)
                {
                    return Results.BadRequest(ex.Errors);
                }
            });

            app.MapPatch("api/task/complete/{id}", async ([FromServices] IRepository repository, [FromRoute] string id) =>
            {
                try
                {
                    await repository.CompleteTask(id);

                    return Results.NoContent();
                }
                catch (Exceptions.RecordNotFoundException)
                {
                    return Results.NotFound();
                }
            });
        }
    }
}