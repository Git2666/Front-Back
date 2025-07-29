using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Book.Domain.Entities;

namespace Server.Book.Infrastructure.EF.Oracle.Configurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.ToTable("BOOKS");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(b => b.FileName)
                .HasColumnName("FILE_NAME")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(b => b.FilePath)
                .HasColumnName("FILE_PATH")
                .HasMaxLength(1024)
                .IsRequired();

            builder.Property(b => b.FileType)
                .HasColumnName("FILE_TYPE")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(b => b.FileSize)
                .HasColumnName("FILE_SIZE")
                .IsRequired();

            builder.Property(b => b.CreatedAt)
                .HasColumnName("CREATED_AT")
                .IsRequired();

            builder.Property(b => b.UpdatedAt)
                .HasColumnName("UPDATED_AT")
                .IsRequired();
        }
    }
}