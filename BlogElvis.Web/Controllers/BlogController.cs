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
        public ActionResult Post(int? Id, int? pagina)
        {
            var conexaoBanco = new ConexaoBanco();

            var post = (from p in conexaoBanco.Posts
                        where p.Id == Id
                        select p).FirstOrDefault();

            if (post == null)
            {
                throw new Exception(string.Format("Post código {0} não encontrado", Id));
            }

            var viewModel = new DetalhesPostViewModel();
            preencherViewModel(post, viewModel, pagina);
            return View(viewModel);
        }

        private void preencherViewModel(Post post, DetalhesPostViewModel viewModel, int? pagina)
        {
            viewModel.Id = post.Id;
            viewModel.Autor = post.Autor;
            viewModel.DataPublicacao = post.Publicacao;
            viewModel.Titulo = post.Titulo;
            viewModel.Resumo = post.Resumo;
            viewModel.Visivel = post.Visivel;
            viewModel.Descricao = post.Descricao;
            viewModel.Tags = post.PostTag.Select(x => x.Tag).ToList();

            var paginaCorreta = pagina.GetValueOrDefault(1);
            var registrosPorPagina = 10;

            var qtdeRegistros = post.Comentarios.Count();

            var indiceDaPagina = paginaCorreta - 1;
            var qtdeRegistrosPular = (indiceDaPagina * registrosPorPagina);
            var qtdePaginas = Math.Ceiling((decimal)qtdeRegistros / registrosPorPagina);

            viewModel.Comentarios = (from p in post.Comentarios
                                     orderby p.DataHora descending
                                     select p).Skip(qtdeRegistrosPular).Take(registrosPorPagina).ToList();

            viewModel.PaginaAtual = paginaCorreta;
            viewModel.TotalAtual = (int) qtdePaginas;

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
                               select new DetalhesPostViewModel
                               {
                                   DataPublicacao = p.Publicacao,
                                   Autor = p.Autor,
                                   Descricao = p.Descricao,
                                   Id = p.Id,
                                   Resumo = p.Resumo,
                                   Titulo = p.Titulo,
                                   Visivel = p.Visivel,
                                   QtdeComentario = p.Comentarios.Count
                               }).Skip(qtdeRegistrosPular).Take(registrosPorPagina).ToList();
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

        [HttpPost]
        public ActionResult Post(DetalhesPostViewModel viewModel)
        {
            var conexaoBanco = new ConexaoBanco();
            var post = (from p in conexaoBanco.Posts
                      where p.Id == viewModel.Id
                      select p).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (post == null)
                {
                    throw new Exception(string.Format("Post código {0} não encontrado.", viewModel.Id));
                };

                var comentario = new Comentario();
                comentario.AdmPost = HttpContext.User.Identity.IsAuthenticated;
                comentario.Descricao = viewModel.ComentarioDescricao;
                comentario.Email = viewModel.ComentarioEmail;
                comentario.IdPost = viewModel.Id;
                comentario.Nome = viewModel.ComentarioNome;
                comentario.PaginaWeb = viewModel.ComentarioPaginaWeb;
                comentario.DataHora = DateTime.Now;

                try
                {
                    conexaoBanco.Comentaos.Add(comentario);
                    conexaoBanco.SaveChanges();
                    return Redirect(Url.Action("Post", new
                    {
                        ano = post.Publicacao.Year,
                        mes = post.Publicacao.Month,
                        dia = post.Publicacao.Day,
                        titulo = post.Titulo,
                        id = post.Id
                    }) + "#comentarios");
                }
                catch (Exception exp)
                {
                    ModelState.AddModelError("", exp.Message);
                }
            }
            preencherViewModel(post, viewModel,null);
            return View(viewModel);
        }
        
    }
}