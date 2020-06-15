using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Boletim.Views.HomeCadastro
{
    public partial class Aluno
    {
        public int UsuarioId { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        public string RM { get; set; }
    }
}
