using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class GastoModel
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