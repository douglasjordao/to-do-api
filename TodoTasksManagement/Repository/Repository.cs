using Database;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Models;
using TodoTasksManagement.Dto;

namespace TodoTasksManagement.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoTask> GetTaskById(string id)
        {
            return await _context.TodoTasks.FirstOrDefaultAsync(t => t.Id == id) ?? throw new RecordNotFoundException();
        }

        public async Task<PaginatedResults<TodoTask>> GetPaginatedResults(int page, int pageSize)
        {
            int startIndex = (page - 1) * pageSize;

            var query = _context.TodoTasks.AsQueryable();

            var totalItems = await query.CountAsync();
            var items = await query.OrderBy(t => t.UpdatedAt)
            .Skip(startIndex)
            .Take(pageSize)
            .ToListAsync();

            return new PaginatedResults<TodoTask>
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                Items = items,
            };
        }

        public async Task<TodoTask> CreateTask(DtoTodoTask dto)
        {

            var newTask = new TodoTask
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            newTask.Validate();

            _context.TodoTasks.Add(newTask);

            await _context.SaveChangesAsync();

            return newTask;
        }

        public async Task UpdateTask(DtoTodoTask dto, string id)
        {
            var record = await GetTaskById(id);

            record.Name = dto.Name;
            record.Description = dto.Description;

            record.Validate();

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(string id)
        {
            var record = await GetTaskById(id);

            _context.TodoTasks.Remove(record);

            await _context.SaveChangesAsync();
        }
    }
}