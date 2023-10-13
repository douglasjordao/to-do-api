namespace TodoTasksManagement.Repository
{
    public static class Register
    {
        public static void RegisterTodoTasksReposiroty(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepository, Repository>();
        }
    }
}