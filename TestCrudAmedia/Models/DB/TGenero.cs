using System;
using System.Collections.Generic;

namespace TestCrudAmedia.Models.DB
{
    public partial class TGenero
    {
        public TGenero()
        {
            TGeneroPelicula = new HashSet<TGeneroPelicula>();
        }

        public int CodGenero { get; set; }
        public string TxtDesc { get; set; }

        public virtual ICollection<TGeneroPelicula> TGeneroPelicula { get; set; }
    }
}
