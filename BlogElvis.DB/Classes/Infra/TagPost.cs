﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Classes.Infra
{
    public class TagPost:ClasseBase
    {
        public string IdTag { get; set; }
        public int IdPost { get; set; }

        public virtual TagClass Tag { get; set; }
        public virtual Post Post { get; set; }
    }
}
