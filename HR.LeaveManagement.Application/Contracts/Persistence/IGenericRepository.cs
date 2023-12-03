namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T: class  
{
    Task<List<T>> GetAsync();
    Task<T> GetAsyncById(string id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
