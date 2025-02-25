using Backend.Blog.Model;
using Backend.IBaseRepository;
using Backend.IBaseService;

namespace Backend.BaseService;

public class ArticleService : BaseService<Article>, IArticleService
{
    public ArticleService(IArticleRepository repository)
    {
        base._repository = repository;
    }
}