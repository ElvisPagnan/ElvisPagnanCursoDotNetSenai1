using BlogElvis.DB;
using BlogElvis.DB.Classes.Infra;
using BlogElvis.Web.Models.Administracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogElvis.Web.Controllers
{

    public class AdministracaoController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult CadastrarPost()
        {

            var viewModel = new CadastrarPOstViewModel();
            viewModel.DataPublicao = DateTime.Now;
            viewModel.HoraPublicao = DateTime.Now;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CadastrarPost(CadastrarPOstViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var conexao = new ConexaoBanco();
                    var posts = new Post();

                    posts.Publicacao = new DateTime(viewModel.DataPublicao.Year,
                                                viewModel.DataPublicao.Month,
                                                viewModel.DataPublicao.Day,
                                                viewModel.HoraPublicao.Hour,
                                                viewModel.HoraPublicao.Minute,
                                                0);

                    posts.Titulo = viewModel.Titulo;
                    posts.Autor = viewModel.Autor;
                    posts.Descricao = viewModel.Descricao;
                    posts.Resumo = viewModel.Resumo;
                    posts.Visivel = viewModel.Visivel;

                    //Insere no banco
                    posts.PostTag = new List<TagPost>();
                    if (viewModel.Tags != null)
                    {
                        foreach (var item in viewModel.Tags)
                        {
                            var tagExiste = (from p in conexao.TagClass
                                            where p.Tag.ToLower() == item.ToLower()
                                           select p).Any();
                            if (!tagExiste)
                            {
                                var tagClass = new TagClass();
                                tagClass.Tag = item;
                                conexao.TagClass.Add(tagClass);
                            }
                            var postTag = new TagPost();
                            postTag.IdTag = item;
                            posts.PostTag.Add(postTag);
                        }
                    }

                    try
                    {
                        conexao.Posts.Add(posts);
                        conexao.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception exp)
                    {
                        ModelState.AddModelError("", exp.Message);
                    }
            }
                catch (Exception)
                {
                    Console.WriteLine("Erro.");
                }
            }
            return View(viewModel);
        }


        public ActionResult EditarPost(int id)
        {

            var conexao = new ConexaoBanco();
            var post = new Post();

            post = (from x in conexao.Posts
                    where x.Id == id
                    select x).FirstOrDefault();

            if (post == null)
            {
                throw new Exception(string.Format("Post com código {0} não encontrado.", id));
            }

            var viewModel = new CadastrarPOstViewModel();

            viewModel.Id = post.Id;
            viewModel.DataPublicao = post.Publicacao;
            viewModel.HoraPublicao = post.Publicacao;
            viewModel.Titulo = post.Titulo;
            viewModel.Autor = post.Autor;
            viewModel.Descricao = post.Descricao;
            viewModel.Resumo = post.Resumo;
            viewModel.Visivel = post.Visivel;

            viewModel.Tags = (from p in post.PostTag
                              select p.IdTag).ToList(); 
                         
            
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult EditarPost(CadastrarPOstViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var conexao = new ConexaoBanco();
                var post = new Post();

                post = (from x in conexao.Posts
                        where x.Id == viewModel.Id
                        select x).FirstOrDefault();

                post.Publicacao = new DateTime(viewModel.DataPublicao.Year,
                                             viewModel.DataPublicao.Month,
                                             viewModel.DataPublicao.Day,
                                             viewModel.HoraPublicao.Hour,
                                             viewModel.HoraPublicao.Minute,
                                             0);

                post.Titulo = viewModel.Titulo;
                post.Autor = viewModel.Autor;
                post.Descricao = viewModel.Descricao;
                post.Resumo = viewModel.Resumo;
                post.Visivel = viewModel.Visivel;

                var postsTagsAtuais = post.PostTag.ToList();

                foreach (var item in postsTagsAtuais)
                {
                    conexao.TagPost.Remove(item);
                }

                if (viewModel.Tags != null)
                {
                    foreach (var item in viewModel.Tags)
                    {
                        var tagExiste = (from p in conexao.TagClass
                                         where p.Tag.ToLower() == item.ToLower()
                                         select p).Any();
                        if (!tagExiste)
                        {
                            var tagClass = new TagClass();
                            tagClass.Tag = item;
                            conexao.TagClass.Add(tagClass);
                        }
                        var postTag = new TagPost();
                        postTag.IdTag = item;
                        post.PostTag.Add(postTag);
                    }
                }

                try
                {
                    conexao.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception exp)
                {
                    ModelState.AddModelError("", exp.Message);
                    return View(viewModel);
                }
            }
            else
            {
                return View(viewModel);
            }

        }

        public ActionResult ExcluirPost(int id)
        {
            var conexaoBanco = new ConexaoBanco();
            var post = (from p in conexaoBanco.Posts 
                        where p.Id == id
                        select p).FirstOrDefault();

            if (post == null)
            {
                throw new Exception(string.Format("Post com código {0} não encontrado.", id));
            }

            conexaoBanco.Posts.Remove(post);
            conexaoBanco.SaveChanges();

            return RedirectToAction("Index","Blog");
        }

        #region ExcluirComentario
        public ActionResult ExcluirComentario(int id)
        {
            var conexaoBanco = new ConexaoBanco();
            var comentario = (from p in conexaoBanco.Comentaos
                              where p.Id == id
                              select p).FirstOrDefault();
            if (comentario == null)
            {
                throw new Exception(string.Format("Comentário código {0} não foi encontrado.", id));
            }
            conexaoBanco.Comentaos.Remove(comentario);
            conexaoBanco.SaveChanges();

            var post = (from p in conexaoBanco.Posts
                        where p.Id == comentario.IdPost
                        select p).First();
            return Redirect(Url.Action("Post", "Blog", new
            {
                ano = post.Publicacao.Year,
                mes = post.Publicacao.Month,
                dia = post.Publicacao.Day,
                titulo = post.Titulo,
                id = post.Id
            }) + "#comentarios");
        }
        #endregion
    }


}