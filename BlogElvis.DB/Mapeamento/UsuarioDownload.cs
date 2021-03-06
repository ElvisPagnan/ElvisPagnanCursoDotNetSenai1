﻿using BlogElvis.DB.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Mapeamento
{
    class UsuarioConfig:EntityTypeConfiguration<Dowload>
    {
        //ctor
        public UsuarioConfig()
        {
            ToTable("LOGIN");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("IDUSUARIO")
                .HasColumnName
                .IsRequired()
                .HasDatabaseGenerateOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Login)
                .HasColumnName("LOGIN")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Login)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Login)
                .HasColumnName("SENHA")
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
