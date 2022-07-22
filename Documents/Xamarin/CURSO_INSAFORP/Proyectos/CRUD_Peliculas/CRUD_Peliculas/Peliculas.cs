using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUD_Peliculas
{
    public class Peliculas
    {
        [PrimaryKey, AutoIncrement]
        public int IdPelicula { get; set; }
        public string NombrePelicula { get; set; }

    }
}
