using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGastos.Models
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public string Importe { get; set; }
        public System.DateTime? Fecha { get; set; }
        public string Descorta { get; set; }
        public string Etiquetas { get; set; }


    }
}