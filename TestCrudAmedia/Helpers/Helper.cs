using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCrudAmedia.Models.DB;

namespace TestCrudAmedia.Helpers
{
    public static class Helper
    {
        public static bool tienePermiso(string usuario, int rol)
        {
            using (TestCrudContext db = new TestCrudContext())
            {
                return (db.TUsers.FirstOrDefault(u => u.TxtUser.Equals(usuario) && u.CodRol == rol) != null? true : false) ;
            }

        }


        public static List<dynamic> GetRolesLista()
        {
            List<dynamic> lista = new List<dynamic>();
            lista.Add(new { Value = string.Empty, Text = "Seleccione" });

            using (var db = new TestCrudContext())
            {
                List<TRol> list = new List<TRol>();

                list = db.TRol.OrderBy(t => t.TxtDesc).ToList();

                foreach (TRol rol in list)
                {
                    lista.Add(new { Value = rol.CodRol, Text = rol.TxtDesc });
                }
            }

            return lista;
        }

    }
}
