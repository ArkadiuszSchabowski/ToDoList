using Microsoft.EntityFrameworkCore;
using ToDoList_Server.Interfaces.Aggregates;
using ToDoList_Server.Models.Pagination;
using ToDoList_Server_Database;
using ToDoList_Server_Database.Entities;

namespace ToDoList_Server.Repositories
{
    public class TaskRepository : ITaskAggregateRepository
    {
        private readonly MyDbContext _context;

        public TaskRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<int> CountRecordsAsync()
        {
            return await _context.TaskItems.CountAsync();
        }
        public async Task AddAsync(TaskItem item)
        {
            _context.TaskItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskItem>> GetAsync(PaginationDto dto)
        {
            return await _context.TaskItems
                .OrderBy(x => x.Title)
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetAsync(int id)
        {
            return await _context.TaskItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskItem?> GetTitleAsync(string title)
        {
            return await _context.TaskItems.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task RemoveAsync(TaskItem item)
        {
            _context.TaskItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
