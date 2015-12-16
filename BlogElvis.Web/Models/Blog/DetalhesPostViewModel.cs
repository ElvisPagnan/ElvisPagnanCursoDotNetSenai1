using BlogElvis.DB.Classes.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogElvis.Web.Models
{
    public class DetalhesPostViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public bool Visivel { get; set; }
        public int QtdeComentario { get; set; }
        public List<TagClass> Tags { get; set; }

        /*CADASTRAR COMENTARIO*/
        [DisplayName("Nome")]
        [StringLength(100, ErrorMessage = "O campo Nome deve possuir no máximo {1} caracteres!")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string ComentarioNome { get; set; }
        [DisplayName("E-mail")]
        [StringLength(100, ErrorMessage = "O campo E-mail deve possuir no máximo {1} caracteres!")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório")]
        public string ComentarioEmail { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo Descriação é obrigatório")]
        public string ComentarioDescricao { get; set; }
        [DisplayName("Página Web")]
        [StringLength(100, ErrorMessage = "O campo Página Web deve possuir no máximo {1} caracteres!")]
        public string ComentarioPaginaWeb { get; set; }


    }
}