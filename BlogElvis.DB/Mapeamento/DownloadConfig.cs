using BlogElvis.DB.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Mapeamento
{
    public class DownloadConfig: EntityTypeConfiguration<Dowload>
    {
        public DownloadConfig()
        {
            ToTable("DOWNLOAD");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("IDDOWNLOAD")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.DataHora)
                .HasColumnName("DATAHORA")
                .IsRequired();

            Property(x => x.IdArquivo)
                .HasColumnName("IDAQRQUIVO")
                .IsRequired();

            HasRequired(x => x.Arquivo)
                .WithMany()
                .HasForeignKey(x => x.IdArquivo);

        }
    }
}


