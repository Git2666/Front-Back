using System.Linq.Expressions;

namespace Backend.IBaseService;

public interface IBaseService<T> where T : class
{
    public Task<bool> CreateAsync(T entity);
    
    public Task<bool> UpdateAsync(T entity);
    
    public Task<bool> DeleteAsync(T entity);
    
    public Task<T> GetByIdAsync(Guid id);
    
    public Task<T> GetOneAsync(Expression<Func<T, bool>> predicate);
    
    public Task<List<T>> FindAllAsync();
}