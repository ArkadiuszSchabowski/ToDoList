using ToDoList_Server.Models;

namespace ToDoList_Server.Interfaces.Aggregates
{
    public interface ITaskAggregateService : IAddService<AddTaskDto>, IGetService<GetTaskDto>, IRemoveService, IUpdateTaskStatus
    {

    }
}
