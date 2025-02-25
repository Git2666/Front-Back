using Backend.Blog.Model;
using Backend.IBaseRepository;
using Backend.IBaseService;

namespace Backend.BaseService;

public class ArticleTypeService : BaseService<ArticleType>, IArticleTypeService
{
    public ArticleTypeService(IArticleTypeRepository repository)
    {
        base._repository = repository;
    }
}