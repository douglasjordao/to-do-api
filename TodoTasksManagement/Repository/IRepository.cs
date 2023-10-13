using Entities;
using Models;

namespace TodoTasksManagement.Repository
{
    public interface IRepository
    {
        Task<PaginatedResults<TodoTask>> GetPaginatedResults(int page, int pageSize);
        Task<TodoTask> CreateTask(TodoTask task);
        Task UpdateTask(TodoTask task, string id);
        Task CompleteTask(string id);
    }
}