using ToDoList_Server.Exceptions;
using ToDoList_Server.Interfaces;
using ToDoList_Server.Models;

namespace ToDoList_Server.Validators
{
    public class TaskValidator : ITaskValidator
    {
        public void ValidateTask(AddTaskDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Task is required.");
            }

            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                throw new BadRequestException("Title is required.");
            }

            if (dto.Title.Length < 5 || dto.Title.Length > 50)
            {
                throw new BadRequestException("Please provide a title between 5 and 50 characters.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Description))
            {
                if (dto.Description.Length < 10 || dto.Description.Length > 200)
                {
                    throw new BadRequestException("Description (optional) must be between 10 and 200 characters.");
                }
            }
        }

        public void ValidateTaskStatus(UpdateTaskStatusDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Task status is required.");
            }

            if (dto.Status != Enums.TaskStatus.Completed && dto.Status != Enums.TaskStatus.Pending)
            {
                throw new BadRequestException("Please select a valid status: Pending or Completed.");
            }
        }
    }
}
