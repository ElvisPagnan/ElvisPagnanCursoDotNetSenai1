using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogElvis.Web.Models.Administracao
{
    public class CadastrarUsuarioViewModel
    {
        [DisplayName("Código")]
        public int Id { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "O campo Login é obrigatório.")]
        [StringLength(30, MinimumLength = 2,
         ErrorMessage = "A quantidade de caracters no camp login deve ser entre {2} e {1}.")]
        public string Login { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 2,
         ErrorMessage = "A quantidade de caracters no camo Nome deve ser entre {2} e {1}.")]
        public string Nome { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(100, MinimumLength = 2,
         ErrorMessage = "A quantidade de caracters no campo Senha deve ser entre {2} e {1}.")]
        public string Senha { get; set; }

        [DisplayName("Confirmar senha")]
        [StringLength(100, ErrorMessage = "O campo confirmar senha deve possuir no máximo {1} caracter.")]
        [Required(ErrorMessage = "O campo Conformar Senha é obrigatório.")]
        [Compare("Senha", ErrorMessage = "As senhas digitadas não conferem.")]
        public string ConfirmarSenha { get; set; }

        

    }
}