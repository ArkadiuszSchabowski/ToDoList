using System.ComponentModel.DataAnnotations;

namespace ToDoList_Server.Models
{
    public class UpdateTaskStatusDto
    {
        [Required(ErrorMessage = "Status is required.")]
        public Enums.TaskStatus Status { get; set; }
    }
}
