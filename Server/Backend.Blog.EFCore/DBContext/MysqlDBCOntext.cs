using Backend.Blog.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Blog.EFCore.DBContext;

public class MysqlDBCOntext : DbContext
{
    public MysqlDBCOntext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Article> Articles { get; set; }
    
    public DbSet<ArticleType> ArticleTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //load all classes implement IEntityTypeConfiguration
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}