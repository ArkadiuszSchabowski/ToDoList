using ToDoList_Server.Exceptions;
using ToDoList_Server.Interfaces;
using ToDoList_Server_Database.Entities;

namespace ToDoList_Server.Validators
{
    public class EntityValidator : IEntityValidator<TaskItem>
    {
        public void ThrowIfEntityExist(TaskItem? entity)
        {
            if (entity != null)
            {
                throw new ConflictException("Task already exists in database.");
            }
        }

        public void ThrowIfEntityIsNull(TaskItem? dto)
        {
            if (dto == null)
            {
                throw new NotFoundException("Task not found.");
            }
        }
    }
}
