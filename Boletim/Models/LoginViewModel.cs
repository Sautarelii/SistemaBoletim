using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boletim.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
    public string Senha { get; set; }
    }
}