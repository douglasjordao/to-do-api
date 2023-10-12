using Database;
using Entities;
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
    }
}