using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGastos.Models
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public float Importe { get; set; }
        public System.DateTime? Fecha { get; set; }
        public string Descorta { get; set; }
        public string Deslarga { get; set; }
    }
}