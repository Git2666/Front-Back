using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Book.Domain.Entities;
using Server.Book.Domain.Interfaces;

namespace Server.Book.Infrastructure.EF.Oracle.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ServerBookDbContext _dbContext;

        public BookRepository(ServerBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookEntity> GetByIdAsync(Guid id)
        {
            return await _dbContext.Books.FindAsync(id) 
                   ?? throw new KeyNotFoundException($"Book with Id '{id}' not found.");
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            return await _dbContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(BookEntity book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookEntity book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}