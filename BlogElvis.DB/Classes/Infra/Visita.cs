using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Classes.Infra
{
    public class Visita:ClasseBase
    {
        public string IP{ get; set; }
        public DateTime DataHora { get; set; }
        public int IdPost { get; set; }

        public virtual Post Post { get; set; }
    }
}
