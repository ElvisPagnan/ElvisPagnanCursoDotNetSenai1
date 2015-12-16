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
    class ComentarioConfig:EntityTypeConfiguration<Comentario>
    {
        public ComentarioConfig()
        {
            ToTable("COMENTARIO");

            HasKey(x => x.Id);

            Property(x => x.Id)
                   .HasColumnName("IDCOMENTARIO")
                   .IsRequired()
                   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Descricao)
                   .HasColumnName("DESCRICAO")
                   .IsMaxLength()
                   .IsRequired();

            Property(x => x.AdmPost)
                   .HasColumnName("ADMPOST")
                   .IsRequired();

            Property(x => x.Email)
                   .HasColumnName("EMAIL")
                   .IsMaxLength()
                   .IsRequired();

            Property(x => x.PaginaWeb)
                   .HasColumnName("PAGINAWEB")
                   .IsMaxLength()
                   .IsRequired();

            Property(x => x.Nome)
                  .HasColumnName("NOME")
                  .IsMaxLength()
                  .IsRequired();

            Property(x => x.IdPost)
               .HasColumnName("IDPOST")
               .IsRequired();

            HasRequired(x => x.Post)
               .WithMany()
               .HasForeignKey(x => x.IdPost);



        }



    }
}
