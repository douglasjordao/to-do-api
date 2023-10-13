using Database;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Models;

namespace TodoTasksManagement.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResults<TodoTask>> GetPaginatedResults(int page, int pageSize)
        {
            int startIndex = (page - 1) * pageSize;

            var query = _context.TodoTasks.AsQueryable();

            var totalItems = await query.CountAsync();
            var items = await query.Skip(startIndex).Take(pageSize).ToListAsync();

            return new PaginatedResults<TodoTask>
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                Items = items
            };
        }

        public async Task<TodoTask> CreateTask(TodoTask task)
        {
            task.Validate();

            var newTask = new TodoTask
            {
                Name = task.Name,
                Description = task.Description,
                Done = false,
            };

            _context.TodoTasks.Add(newTask);

            await _context.SaveChangesAsync();

            return newTask;
        }

        public async Task UpdateTask(TodoTask task, string id)
        {
            var record = await _context.TodoTasks.FirstOrDefaultAsync(t => t.Id == id) ?? throw new RecordNotFoundException();

            task.Validate();

            record.Name = task.Name;
            record.Description = task.Description;
            record.Done = task.Done;

            await _context.SaveChangesAsync();
        }
    }
}