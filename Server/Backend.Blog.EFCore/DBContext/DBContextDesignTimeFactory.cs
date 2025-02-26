using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.Blog.EFCore.DBContext;

public class DBContextDesignTimeFactory : IDesignTimeDbContextFactory<MysqlDBCOntext>
{
    public MysqlDBCOntext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<MysqlDBCOntext> builder = new DbContextOptionsBuilder<MysqlDBCOntext>();
        builder.UseMySql("server=localhost;user=root;password=111222;database=data",  new MySqlServerVersion(new Version(10,7,1)));
        return new MysqlDBCOntext(builder.Options);
    }
}