using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Bussines
{
    public class BussinesDatos
    {
        public List<ResultadosModel> Ejecutar(string param)
        {
            using (AplicacionesEntities db = new AplicacionesEntities())
            {
                var e = db.ObtenerAcumuladoGastos(param);

                List<ResultadosModel> aux = new List<ResultadosModel>();

                foreach (var item in e)
                {
                    aux.Add( new ResultadosModel
                    {
                        agrupacion = item.intervalo,
                        etiqueta = item.descorta,
                        dato = item.importe
                    });

                }
                return aux;
            }
        }
    }
}
