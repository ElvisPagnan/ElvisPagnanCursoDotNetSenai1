using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Classes.Infra
{
    public class Arquivo: ClasseBase
    {
        public string Nome { get; set; }
        public string extensao { get; set; }
        public byte[] bytes  { get; set; }
        public int IdPost { get; set; }

        public virtual Post Post { get; set; }
    }
}
