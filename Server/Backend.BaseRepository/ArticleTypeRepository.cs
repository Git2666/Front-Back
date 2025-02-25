using Backend.Blog.Model;
using Backend.IBaseRepository;
using Backend.Blog.EFCore.DBContext;

namespace Backend.BaseRepository;

public class ArticleTypeRepository : BaseRepository<ArticleType>, IArticleTypeRepository
{
    //private readonly MysqlDBCOntext _dbx;

    public ArticleTypeRepository(MysqlDBCOntext dbx)
    {
        base._db = dbx;
        //_dbx = dbx;
    }
}