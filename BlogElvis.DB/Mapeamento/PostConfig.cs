using BlogElvis.DB.Classes.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Mapeamento
{
    public class PostConfig:EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            ToTable("POST");

            HasKey(x => x.Id);

            Property(x => x.Id)
               .HasColumnName("IDPOST")
               .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Autor)
               .HasColumnName("AUTOR")
               .IsMaxLength()
               .IsRequired();

            Property(x => x.Publicacao)
               .HasColumnName("DATAPUBLICACAO")
               .IsRequired();

            Property(x => x.Descricao)
               .HasColumnName("DESCRICAO")
               .IsRequired();

            Property(x => x.Resumo)
               .HasColumnName("RESUMO")
               .IsRequired();

            Property(x => x.Titulo)
               .HasColumnName("TITULO")
               .IsRequired();

            Property(x => x.Visivel)
               .HasColumnName("VISIVEL")
               .IsRequired();

            HasMany(x => x.Arquivos)
                .WithOptional()
                .HasForeignKey(x => x.IdPost);

            HasMany(x => x.Comentarios)
                .WithOptional()
                .HasForeignKey(x => x.IdPost);

            HasMany(x => x.Imagens)
                .WithOptional()
                .HasForeignKey(x => x.IdPost);

            HasMany(x => x.Visitas)
                .WithOptional()
                .HasForeignKey(x => x.IdPost);

            HasMany(x => x.PostTag)
                .WithOptional()
                .HasForeignKey(x => x.IdPost);

        }
    }
}
