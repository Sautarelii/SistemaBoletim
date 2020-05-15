using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Boletim.Models
{
    public class Administrador
    {
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigadoria")]
        public string Senha { get; set; }


    }

    
}

        
       

