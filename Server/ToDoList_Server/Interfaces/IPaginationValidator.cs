using ToDoList_Server.Models.Pagination;

namespace ToDoList_Server.Interfaces
{
    public interface IPaginationValidator
    {
        void ValidatePagination(PaginationDto dto);
    }
}
