using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEFFluentMapping.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Table
            builder.ToTable("Category");

            //Chave Primária
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(); // Primary key e o Identity(1,1)

            //Propriedades
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnName("Name") //Esse método deve ser chamado apenas se o nome da propriedade for diferente da coluna.
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(80);

            builder.Property(x => x.Slug)
                  .IsRequired()
                  .HasColumnName("Slug") //Esse método deve ser chamado apenas se o nome da propriedade for diferente da coluna.
                  .HasColumnType("VARCHAR")
                  .HasMaxLength(80);

            // Índices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                   .IsUnique(); // => garante quea categoria seja unica
        }
    }
}
