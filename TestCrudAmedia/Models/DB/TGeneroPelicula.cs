using System;
using System.Collections.Generic;

namespace TestCrudAmedia.Models.DB
{
    public partial class TGeneroPelicula
    {
        public int CodPelicula { get; set; }
        public int CodGenero { get; set; }

        public virtual TGenero CodGeneroNavigation { get; set; }
        public virtual TPelicula CodPeliculaNavigation { get; set; }
    }
}
