namespace ToDoList_Server.Interfaces
{
    public interface IEntityValidator<T> where T : class
    {
        void ThrowIfEntityExist(T? entity);
        void ThrowIfEntityIsNull(T? entity);
    }
}
