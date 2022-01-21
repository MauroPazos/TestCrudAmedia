using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestCrudAmedia.Helpers;
using TestCrudAmedia.Models.DB;

namespace TestCrudAmedia.Models
{
    public class UsuarioModel
    {
        [Display(Name = "ID de Usuario")]
        public int CodUsuario { get; set; }

        [Display(Name = "Nombre de Usuario")]
        public string TxtUser { get; set; }

        [Display(Name = "Contraseña")]
        public string TxtPassword { get; set; }

        [Display(Name = "Nombre")]
        public string TxtNombre { get; set; }

        [Display(Name = "Apellido")]
        public string TxtApellido { get; set; }

        [Display(Name = "Número de documento")]
        public string NroDoc { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public int? CodRol { get; set; }
        public int? SnActivo { get; set; }
        public string accion { get; set; }

    }
}
