using Entities;
using Models;
using TodoTasksManagement.Dto;

namespace TodoTasksManagement.Repository
{
    public interface IRepository
    {
        Task<TodoTask> GetTaskById(string id);
        Task<PaginatedResults<TodoTask>> GetPaginatedResults(int page, int pageSize);
        Task<TodoTask> CreateTask(DtoTodoTask dto);
        Task UpdateTask(DtoTodoTask dto, string id);
        Task DeleteTask(string id);
    }
}