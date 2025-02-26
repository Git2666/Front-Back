namespace Backend.Blog.Model;

public class Article : BaseModel
{
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public DateTime CreateTime { get; set; }
    
    //public ArticleType Type { get; set; }
    
    public Guid TypeId { get; set; }
    
    //public User Author { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public int ViewCount { get; set; }
    
    public int LikeCount { get; set; }
    
}
