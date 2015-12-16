using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Classes.Infra
{
    public class Post : ClasseBase
    {
        public string Autor { get; set; }
        public DateTime Publicacao { get; set; }
        public string Descricao { get; set; }
        public string Resumo { get; set; }
        public string Titulo { get; set; }
        public bool Visivel { get; set; }

        public virtual IList<Comentario> Comentarios { get; set; }
        public virtual IList<Comentario> Arquivos { get; set; }
        public virtual IList<Comentario> Imagens { get; set; }
        public virtual IList<Visita> Visitas { get; set; }
        public virtual IList<TagPost>  PostTag { get; set; }

    }
}
