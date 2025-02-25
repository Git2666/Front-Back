using AutoMapper;
using Backend.Blog.Model;
using Backend.Blog.Model.DTO;

namespace Backend.Util.Mapper;

public class DTOMapper : Profile
{
    public DTOMapper()
    {
        //Article
        base.CreateMap<Article, ArticleDTO>();

        //ArticleType
        base.CreateMap<ArticleType, ArticleTypeDTO>();

    }
}