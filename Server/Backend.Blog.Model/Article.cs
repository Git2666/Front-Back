namespace Backend.Blog.Model;

public class Article : BaseId
{
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public DateTime CreateTime { get; set; }
    
    public ArticleType Type { get; set; }
    
    public Guid TypeId { get; set; }
    
    public int ViewCount { get; set; }
    
    public int LikeCount { get; set; }
    
    public bool IsDeleted { get; set; }
}
