using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogElvis.Web.Models.Administracao
{
    public class CadastrarPOstViewModel
    {
        [DisplayName("Código")]
        public int Id { get; set;}

        [DisplayName("Título")]
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength( 100, MinimumLength = 2, 
         ErrorMessage = "A quantidade de caracters no camp título deve ser entre {2} e {1}.")]

        public string Titulo { get; set; }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "O campo Autor é obrigatório.")]
        [StringLength(100, MinimumLength = 2, 
         ErrorMessage = "A quantidade de caracters no camo Autor deve ser entre {2} e {1}.")]
        public string Autor { get; set; }

        [DisplayName("Resumo")]
        [Required(ErrorMessage = "O campo Resumo é obrigatório.")]
        [StringLength(100, MinimumLength = 2,
         ErrorMessage = "A quantidade de caracters no campo Resumo deve ser entre {2} e {1}.")]
        public string Resumo { get; set; }

        [DisplayName("Descricao")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(100, MinimumLength = 2,
         ErrorMessage = "A quantidade de caracters no campo título deve ser entre {2} e {1}.")]
        public string Descricao { get; set; }

        [DisplayName("Data de Publicação")]
        [Required(ErrorMessage = "O campo Data de Publicação é obrigatório.")]
        public DateTime DataPublicao { get; set; }

        [DisplayName("Hora de Publicação")]
        [Required(ErrorMessage = "O campo Hora de Publicação é obrigatório.")]
        public DateTime HoraPublicao { get; set; }

        [DisplayName("Visível")]
        [Required(ErrorMessage = "O campo Visível é obrigatório.")]
        public bool Visivel { get; set; }

        public List<string> Tags {get; set;}
    }
}