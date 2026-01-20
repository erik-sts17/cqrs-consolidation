namespace CQRS.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Add(T entity);
        void Update(T entity);
        Task<T?> Delete (int id);
    }
}