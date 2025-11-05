namespace ToDoList_Server.Interfaces
{
    public interface IAddService<T> where T : class
    {
        Task AddAsync(T dto);
    }
}
