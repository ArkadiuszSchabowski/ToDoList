namespace ToDoList_Server_Database.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ToDoList_Server.Enums.TaskStatus Status { get; set; }
    }
}
