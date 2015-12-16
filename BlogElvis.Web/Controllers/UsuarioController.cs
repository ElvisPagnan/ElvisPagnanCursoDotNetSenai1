using BlogElvis.DB;
using BlogElvis.DB.Classes;
using BlogElvis.Web.Models.Administracao;
using BlogElvis.Web.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogElvis.Web.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            var conexaoBanco = new ConexaoBanco();

            var usuarios = (from p in conexaoBanco.Usuarios
                            select p);

            var viewModel = new ListarUsuarioViewModel();
            viewModel.Usuarios = usuarios.ToList();


            return View(viewModel);
        }

        public ActionResult CadastrarUsuario()
        {

            var viewModel = new CadastrarUsuarioViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(CadastrarUsuarioViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var conexao = new ConexaoBanco();
                    var usuarios = new Usuario();

                    usuarios.Login = viewModel.Login;
                    usuarios.Nome = viewModel.Nome;
                    usuarios.Senha = viewModel.Senha;

                    try
                    {
                        var existe = (from x in conexao.Usuarios
                                      where x.Nome == usuarios.Nome
                                      select x).Any();
                        if (existe)
                        {
                            throw new Exception(string.Format("Usuário com nome {0} já existe.", usuarios.Nome));
                        }

                        conexao.Usuarios.Add(usuarios);
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

        public ActionResult EditarUsuario(int id)
        {

            var conexao = new ConexaoBanco();
            var usuario = new Usuario();

            usuario = (from x in conexao.Usuarios
                       where x.Id == id
                       select x).FirstOrDefault();

            if (usuario == null)
            {
                throw new Exception(string.Format("Usuário com código {0} não encontrado.", id));
            }

            var viewModel = new CadastrarUsuarioViewModel();

            viewModel.Id = usuario.Id;
            viewModel.Login = usuario.Login;
            viewModel.Nome = usuario.Nome;
            viewModel.Senha = usuario.Senha;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditarUsuario(CadastrarUsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var conexao = new ConexaoBanco();
                var usuario = new Usuario();

                usuario = (from x in conexao.Usuarios
                           where x.Id == viewModel.Id
                           select x).FirstOrDefault();

                usuario.Login = viewModel.Login;
                usuario.Nome = viewModel.Nome;
                usuario.Senha = viewModel.Senha;

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

        public ActionResult ExcluirUsuario(int id)
        {
            var conexaoBanco = new ConexaoBanco();
            var usuario = (from p in conexaoBanco.Usuarios
                           where p.Id == id
                           select p).FirstOrDefault();

            if (usuario == null)
            {
                throw new Exception(string.Format("Usuário com código {0} não encontrado.", id));
            }

            conexaoBanco.Usuarios.Remove(usuario);
            conexaoBanco.SaveChanges();

            return RedirectToAction("Index", "Usuario");
        }
    }
}