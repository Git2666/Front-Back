using Microsoft.EntityFrameworkCore;
using Server.Book.Domain.Entities;

namespace Server.Book.Infrastructure.EF.Oracle
{
    public class ServerBookDbContext : DbContext
    {
        public ServerBookDbContext(DbContextOptions<ServerBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookEntity> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 应用配置
            modelBuilder.ApplyConfiguration(new Configurations.BookEntityTypeConfiguration());
        }
    }
}