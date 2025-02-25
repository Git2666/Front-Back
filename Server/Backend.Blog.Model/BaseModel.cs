namespace Backend.Blog.Model;

public class BaseModel
{
    public Guid Id { get; set; }
    
    public bool IsDeleted { get; set; }
}