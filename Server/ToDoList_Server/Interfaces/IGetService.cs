using ToDoList_Server.Models.Pagination;

namespace ToDoList_Server.Interfaces
{
    public interface IGetService<T> where T : class
    {
        Task<PaginationResult<T>> GetAsync(PaginationDto dto);
    }
}
