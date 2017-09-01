using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_grupo.Models
{
    public class Tarea
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Complejidad { get; set; }
    }
}