using ToDoList_Server_Database.Entities;

namespace ToDoList_Server.Interfaces.Aggregates
{
    public interface ITaskAggregateValidator : IEntityValidator<TaskItem>, IValidatorId, ITaskValidator, IPaginationValidator
    {

    }
}
