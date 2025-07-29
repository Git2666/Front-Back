using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Book.Domain.Entities;

namespace Server.Book.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<BookEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<BookEntity>> GetAllAsync();
        Task AddAsync(BookEntity book);
        Task UpdateAsync(BookEntity book);
        Task DeleteAsync(Guid id);
    }
}