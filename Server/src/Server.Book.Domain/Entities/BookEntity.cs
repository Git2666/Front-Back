namespace Server.Book.Domain.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }             // 主键
        public string FileName { get; set; }     // 文件名
        public string FilePath { get; set; }     // 绝对路径
        public string FileType { get; set; }     // 文件类型，如 pdf, epub
        public string FileSize { get; set; }       // 文件大小（字节）
        public DateTime CreatedAt { get; set; }  // 创建时间
        public DateTime UpdatedAt { get; set; }  // 更新时间

        // 你可以根据业务添加更多字段，比如作者、简介等
    }
}