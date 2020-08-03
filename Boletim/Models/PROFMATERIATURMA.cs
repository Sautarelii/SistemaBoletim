using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boletim.Models
{
    public class PROFMATERIATURMA
    {
        public int PROFMATERIATURMAid { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(100)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe o E-mail")]
        [Display(Name = "E-mail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um e-mail válido")]
        [DataType(DataType.EmailAddress)]
        [Remote("VerificaSeEmailJaExiste", "PROFMATERIATURMA", ErrorMessage = "E-mail já utilizado")]
        public string Email { get; set; }

    }
}