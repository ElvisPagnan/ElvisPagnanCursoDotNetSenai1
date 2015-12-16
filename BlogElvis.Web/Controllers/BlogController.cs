using BlogElvis.DB;
using BlogElvis.DB.Classes.Infra;
using BlogElvis.Web.Models;
using BlogElvis.Web.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BlogElvis.Web.Controllers
{
    public class BlogController : Controller
    {
        #region Post
        public ActionResult Post(int? Id)
        {
            var conexaoBanco = new ConexaoBanco();

            var post = (from p in conexaoBanco.Posts
                        where p.Id == Id
                        select new DetalhesPostViewModel
                        {
                            Id = p.Id,
                            Autor = p.Autor,
                            DataPublicacao = p.Publicacao,
                            Titulo = p.Titulo,
                            Resumo = p.Resumo,
                            Visivel = p.Visivel,
                            Descricao = p.Descricao,

                            Tags = p.PostTag.Select(x => x.Tag).ToList()
                        }).FirstOrDefault();

            if (post == null)
            {
                throw new Exception(string.Format("Post código {0} não encontrado", Id));
            }

            return View(post);
        }
        #endregion


        // GET: Blog
        public ActionResult Index(int? pagina, string tag, string pesquisa)
        {

            var paginaCorreta = pagina.GetValueOrDefault(1);
            var registrosPorPagina = 10;

            var conexaoBanco = new ConexaoBanco();

            var posts = (from p in conexaoBanco.Posts
                         where p.Visivel == true
                         select p);

            if (!string.IsNullOrEmpty(tag))
            {
                posts = (from p in posts
                         where p.PostTag.Any(x => x.IdTag.ToUpper() == tag.ToUpper())
                         select p);
            }

            if (!string.IsNullOrEmpty(pesquisa))
            {
                posts = (from p in posts
                         where p.Titulo.ToUpper().Contains(pesquisa.ToUpper())
                         select p);
            }

            var qtdeRegistros = posts.Count();
            var indiceDaPagina = paginaCorreta - 1;
            var qtdeRegistrosPular = (indiceDaPagina * registrosPorPagina);
            var qtdePaginas = Math.Ceiling((decimal)qtdeRegistros / registrosPorPagina);

            var viewModel = new ListarPostViewModel();
            viewModel.Posts = (from p in posts
                               orderby p.Publicacao descending //(Só colocar aqui)
                               select p).Skip(qtdeRegistrosPular).Take(registrosPorPagina).ToList();
            viewModel.PaginaAtual = paginaCorreta;
            viewModel.TotalPaginas = (int)qtdePaginas;
            viewModel.Tag = tag;
            viewModel.Tags = (from p in conexaoBanco.TagClass
                              where conexaoBanco.TagPost.Any(x => x.IdTag == p.Tag)
                              orderby p.Tag 
                              select p.Tag).ToList();
            viewModel.Pesquisa = pesquisa;

            return View(viewModel);
        }

        public ActionResult _Paginacao()
        {
            return PartialView();
        }


    }
}