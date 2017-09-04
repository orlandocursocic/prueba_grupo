using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prueba_grupo.Models
{
    [Table("Campos")]
    public class Campo
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double? MaxValue { get; set; }
        public double? MinValue { get; set; }
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }
        string TareaAsociada { get; set; }
    }
}