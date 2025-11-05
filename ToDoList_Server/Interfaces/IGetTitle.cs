using ToDoList_Server_Database.Entities;

namespace ToDoList_Server.Interfaces
{
    public interface IGetTitle
    {
        Task<TaskItem?> GetTitleAsync(string title);
    }
}
