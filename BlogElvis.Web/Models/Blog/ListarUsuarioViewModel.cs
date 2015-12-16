using BlogElvis.DB.Classes;
using BlogElvis.DB.Classes.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogElvis.Web.Models.Blog
{
    public class ListarUsuarioViewModel
    {
        public List<Usuario> Usuarios { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
    }
}