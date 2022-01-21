using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCrudAmedia.Models.DB
{
    public partial class TRol
    {
        public TRol()
        {
            TUsers = new HashSet<TUsers>();
        }

        public int CodRol { get; set; }
        public string TxtDesc { get; set; }
        public int? SnActivo { get; set; }

        public virtual ICollection<TUsers> TUsers { get; set; }

       
    }
}
