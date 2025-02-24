namespace Backend.Blog.Model;

public class ArticleType :BaseId
{
    public string TypeName { get; set; }
    
    public bool IsDeleted { get; set; }
}    