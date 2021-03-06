﻿using BlogElvis.DB.Classes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogElvis.Web.Models.Blog
{
    public class ListarPostViewModel
    {
        public List<DetalhesPostViewModel> Posts { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public string Tag { get; set; }
        public List<string> Tags { get; set; }
        public string Pesquisa { get; set; }

    }
}