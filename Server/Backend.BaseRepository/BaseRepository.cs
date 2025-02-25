using System.Linq.Expressions;
using Backend.Blog.EFCore.DBContext;
using Backend.Blog.Model;
using Backend.IBaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.BaseRepository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    protected MysqlDBCOntext _db;
    
    public async Task<bool> CreateAsync(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _db.Set<T>().Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        entity.IsDeleted = true;
        _db.Set<T>().Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _db.Set<T>().FindAsync(id);
    }

    public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate)
    {
        return await _db.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<List<T>> FindAllAsync()
    {
        return await _db.Set<T>().ToListAsync();
    }
}