using ToDoList_Server_Database.Entities;

namespace ToDoList_Server.Interfaces.Aggregates
{
    public interface ITaskAggregateRepository : IRepository<TaskItem>, IGetTitle, ICounterRecords, ISaveChanges
    {

    }
}
