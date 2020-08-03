using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boletim.Models
{
    public class ProfessorViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Professorid { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(100)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe o E-mail")]
        [Display(Name = "E-mail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um e-mail válido")]
        [DataType(DataType.EmailAddress)]
        [Remote("VerificaSeEmailJaExiste", "Administrador", ErrorMessage = "E-mail já utilizado")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [StringLength(25)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme a Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Senha")]
        [StringLength(25)]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }

        [Display(Name = "Senha Temporária?")]
        public bool SenhaTemporaria { get; set; } = true;
    }
}
    