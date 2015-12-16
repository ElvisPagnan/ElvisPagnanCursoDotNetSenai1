using BlogElvis.DB.Classes;
using BlogElvis.DB.Classes.Infra;
using BlogElvis.DB.Infra;
using BlogElvis.DB.Mapeamento;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ConexaoBanco : DbContext
    {
        #region Contructor class
        public ConexaoBanco() : base("ConexaoMySQL")
        {
            Database.Log = (p => Debug.WriteLine(p));
        }

        #endregion
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Comentario> Comentaos { get; set; }
        public DbSet<Dowload> Downloads { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<TagPost> TagPost { get; set; }
        public DbSet<TagClass> TagClass { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Visita> Visitas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ConexaoBanco>(new MeuCriadorDeBanco());
            modelBuilder.Configurations.Add(new ArquivoConfig());
            modelBuilder.Configurations.Add(new ComentarioConfig());
            modelBuilder.Configurations.Add(new DownloadConfig());
            modelBuilder.Configurations.Add(new ImagemConfig());
            modelBuilder.Configurations.Add(new TagPostConfig());
            modelBuilder.Configurations.Add(new TagClassConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new VisitaConfig());
            modelBuilder.Configurations.Add(new PostConfig());

            base.OnModelCreating(modelBuilder);

        }       
    }

}
