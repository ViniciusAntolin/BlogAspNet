﻿using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEFFluentMapping.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<PostResult>
    {
        public void Configure(EntityTypeBuilder<PostResult> builder)
        {
            // Tabela
            builder.ToTable("Post");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                .HasDefaultValueSql("GETDATE()");
            // .HasDefaultValue(DateTime.Now.ToUniversalTime());

            // Índices
            builder
                .HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique();

            //Relacionamentos OneToMany
            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Posts)
                   .HasConstraintName("FK_Post_Author")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Posts)
                   .HasConstraintName("FK_Post_Category")
                   .OnDelete(DeleteBehavior.Cascade);

            //Relacionamentos ManyToMany
            builder.HasMany(x => x.Tags)
                   .WithMany(x => x.Posts)
                   .UsingEntity<Dictionary<string, Object>>("PostTag",
                                post => post.HasOne<TagResult>()
                                            .WithMany()
                                            .HasForeignKey("PostId")
                                            .HasConstraintName("FK_PostTag_PostId")
                                            .OnDelete(DeleteBehavior.Cascade),
                                tag => tag.HasOne<PostResult>()
                                          .WithMany()
                                          .HasForeignKey("TagId")
                                          .HasConstraintName("FK_PostTag_TagId")
                                          .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
