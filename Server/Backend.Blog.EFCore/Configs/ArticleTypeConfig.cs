using Backend.Blog.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Blog.EFCore.Configs;

public class ArticleTypeConfig : IEntityTypeConfiguration<ArticleType>
{
    public void Configure(EntityTypeBuilder<ArticleType> builder)
    {
        builder.ToTable("ArticleType");
        
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}