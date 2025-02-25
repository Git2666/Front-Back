using System.Linq.Expressions;
using Backend.IBaseRepository;
using Backend.IBaseService;

namespace Backend.BaseService;

public class BaseService<T> : IBaseService<T> where T : class
{
    protected IBaseRepository<T> _repository;
    
    public async Task<bool> CreateAsync(T entity)
    {
        return await _repository.CreateAsync(entity);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        return await _repository.DeleteAsync(entity);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await  _repository.GetByIdAsync(id);
    }

    public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate)
    {
        return await _repository.GetOneAsync(predicate);
    }

    public async Task<List<T>> FindAllAsync()
    {
        return await _repository.FindAllAsync();
    }
}