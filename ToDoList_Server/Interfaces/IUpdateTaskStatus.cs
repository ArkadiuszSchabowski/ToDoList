using ToDoList_Server.Models;

namespace ToDoList_Server.Interfaces
{
    public interface IUpdateTaskStatus
    {
        Task UpdateTaskStatusAsync(int id, UpdateTaskStatusDto dto);
    }
}
