using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGastos.Models
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        [Required]
        public string Importe { get; set; }
        public System.DateTime? Fecha { get; set; }
        [Required]
        public string Descorta { get; set; }
        [Required]

        public string Etiquetas { get; set; }


    }
}