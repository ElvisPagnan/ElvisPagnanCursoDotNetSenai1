using BlogElvis.DB.Classes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Classes
{
    public class Dowload : ClasseBase
    {
        public string IP { get; set; }
        public DateTime DataHora { get; set; }
        public int IdArquivo { get; set; }

        public virtual Arquivo Arquivo { get; set; }

    }
}

