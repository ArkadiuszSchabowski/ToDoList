using ToDoList_Server.Models.Pagination;

namespace ToDoList_Server.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<List<T>> GetAsync(PaginationDto dto);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
