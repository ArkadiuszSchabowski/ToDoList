using ToDoList_Server.Exceptions;
using ToDoList_Server.Interfaces;
using ToDoList_Server.Models.Pagination;

namespace ToDoList_Server.Validators
{
    public class PaginationValidator : IPaginationValidator
    {
        public void ValidatePagination(PaginationDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Pagination parameters are required.");
            }

            if (dto.PageSize < 1 || dto.PageSize > 100)
            {
                throw new BadRequestException("Page size must be between 1 and 100.");
            }

            if (dto.PageNumber < 1)
            {
                throw new BadRequestException("Page number must be 1 or higher.");
            }
        }
    }
}
