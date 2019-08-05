using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelos
{
    public class EtiquetaModel
    {
        public int IdEtiqueta { get; set; }
        public Nullable<int> IdSeccion { get; set; }
        public string Descorta { get; set; }
        public string Deslarga { get; set; }
    }
}