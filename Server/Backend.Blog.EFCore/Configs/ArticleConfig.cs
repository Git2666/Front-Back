using Backend.Blog.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Blog.EFCore.Configs;

public class ArticleConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        // table name
        builder.ToTable("Articles");
        
        // avoid the default varchar type has not enough length.
        builder.Property(x => x.Content).HasColumnType("Text");
        
        // config soft delete
        builder.HasQueryFilter(x => !x.IsDeleted);

        //builder.HasOne(x => x.Type);
        
    }
}