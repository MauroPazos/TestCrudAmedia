using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrudAmedia.Models
{
    public class LoginModel
    {
        [Display(Name = "Usuario")]
        public string user { get; set; }

        [Display(Name = "Contraseña")]
        public string pass { get; set; }
        public string returnUrl { get; set; }

    }
}
