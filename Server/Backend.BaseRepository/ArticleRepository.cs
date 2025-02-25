using Backend.Blog.EFCore.DBContext;
using Backend.Blog.Model;
using Backend.IBaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.BaseRepository;

public class ArticleRepository : BaseRepository<Article>, IArticleRepository
{
    //private readonly MysqlDBCOntext _dbx;

    public ArticleRepository(MysqlDBCOntext dbx)
    {
        base._db = dbx;
        //_dbx = dbx;
    }

    public override async Task<List<Article>> FindAllAsync()
    {
        var list = await _db.Articles.ToListAsync();
        foreach (var article in list)
        {
            article.Type = _db.ArticleTypes.Find(article.TypeId);
        }
        return list;
    }
}