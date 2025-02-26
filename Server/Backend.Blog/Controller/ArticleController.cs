using AutoMapper;
using Backend.Blog.Model;
using Backend.Blog.Model.DTO;
using Backend.IBaseService;
using Backend.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Blog.Controller;

[Route("api/[controller]")]
[ApiController]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;
    
    private readonly IMapper _mapper;

    public ArticleController(IArticleService service, IMapper mapper)
    {
        _articleService = service;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    [Authorize]
    public async Task<ActionResult<ApiResult>> GetAllArticles()
    {
        List<Article> data = await _articleService.FindAllAsync();

        List<ArticleDTO> articleDTOs = new List<ArticleDTO>();

        foreach (var article in data)
        {
            articleDTOs.Add(_mapper.Map<ArticleDTO>(article));
        }
        
        return ApiResultHelper.Success(articleDTOs);
    }

    [HttpPost("Create")]
    [Authorize]
    public async Task<ActionResult<ApiResult>> CreateArticle(string title, string content, Guid typeid)
    {
        Article article = new Article()
        {
            Title = title,
            Content = content,
            CreateTime = DateTime.Now,
            TypeId = typeid,
            IsDeleted = false,
            ViewCount = 0,
            LikeCount = 0
        };
        
        var result = await _articleService.CreateAsync(article);
        if (!result)
        {
            return ApiResultHelper.Error("create article error");
        }
        
        return  ApiResultHelper.Success(result);
    }
    
    [HttpDelete("Delete")]
    [Authorize]
    public async Task<ActionResult<ApiResult>> Delete(Guid id)
    {
        Article article = await _articleService.GetByIdAsync(id);
        if (article == null)
        {
            return ApiResultHelper.Error($"删除失败");
        }

        bool result = await _articleService.DeleteAsync(article);

        if (!result)
        {
            return ApiResultHelper.Error($"删除失败! 服务器发生故障!");
        }

        return ApiResultHelper.Success(result);
    }

    [HttpPut("Edit")]
    [Authorize]
    public async Task<ActionResult<ApiResult>> Edit(Guid id, string title, string content, Guid typeid)
    {
        var article = await _articleService.GetByIdAsync(id);
        if (article is null)
        {
            return ApiResultHelper.Error($"修改失败");
        }

        article.Title = title;
        article.Content = content;
        article.TypeId = typeid;

        var result = await _articleService.UpdateAsync(article);

        if (!result)
        {
            return ApiResultHelper.Error($"修改失败");
        }
        return ApiResultHelper.Success(result);
    }
    
}