using ToDoList_Server.Models;

namespace ToDoList_Server.Interfaces
{
    public interface ITaskValidator
    {
        void ValidateTask(AddTaskDto dto);
        void ValidateTaskStatus(UpdateTaskStatusDto dto);
    }
}
