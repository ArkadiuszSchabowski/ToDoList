using System.ComponentModel.DataAnnotations;

namespace ToDoList_Server.Models
{
    public class AddTaskDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 50 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 200 characters.")]
        public string? Description { get; set; }

        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.Pending;
    }
}
