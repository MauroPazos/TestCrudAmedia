using System;
using System.Collections.Generic;

namespace TestCrudAmedia.Models.DB
{
    public partial class TPelicula
    {
        public TPelicula()
        {
            TGeneroPelicula = new HashSet<TGeneroPelicula>();
        }

        public int CodPelicula { get; set; }
        public string TxtDesc { get; set; }
        public int? CantDisponiblesAlquiler { get; set; }
        public int? CantDisponiblesVenta { get; set; }
        public decimal? PrecioAlquiler { get; set; }
        public decimal? PrecioVenta { get; set; }

        public virtual ICollection<TGeneroPelicula> TGeneroPelicula { get; set; }
    }
}
