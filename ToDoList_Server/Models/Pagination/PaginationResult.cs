namespace ToDoList_Server.Models.Pagination
{
    public class PaginationResult<T> where T : class
    {
        public int TotalCount { get; set; }
        public List<T> Results { get; set; } = new List<T>();
    }
}

