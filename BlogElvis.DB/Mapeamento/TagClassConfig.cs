﻿using BlogElvis.DB.Classes.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Mapeamento
{
    public class TagClassConfig : EntityTypeConfiguration<TagClass>
    {
        public TagClassConfig()
        {

            ToTable("TAG");

            HasKey(x => x.Tag);

            Property(x => x.Tag)
                .HasColumnName("IDTAG")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
