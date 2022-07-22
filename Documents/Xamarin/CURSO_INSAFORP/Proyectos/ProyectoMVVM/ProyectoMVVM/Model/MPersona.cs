using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProyectoMVVM.Model
{
    public class MPersona { 
        [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
}
}
