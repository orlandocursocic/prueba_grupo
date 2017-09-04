using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prueba_grupo.Models
{
    [Table("Perfiles")]
    public class Perfil
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Departamento { get; set; }
        public int EdadMedia { get; set; }
        public bool Administrador { get; set; }

    }
}