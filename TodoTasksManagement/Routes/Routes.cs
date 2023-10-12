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
        }
    }
}