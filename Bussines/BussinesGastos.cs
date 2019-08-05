using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Bussines
{
    public class BussinesGastos
    {
        public bool  Ejecutar(GastoModel param)
        {
            using (AplicacionesEntities db = new AplicacionesEntities())
            {
                var e = CrearEtiquetas(param.Etiquetas, db);


                if (param.Fecha == null)
                    param.Fecha = DateTime.UtcNow;


                var aux = new Data.Gastos
                {
                    Descorta = param.Descorta,
                    Fecha = param.Fecha.Value,
                    Importe = float.Parse(param.Importe.Replace('.', ',')),
                    IdEtiqueta = e.IdEtiqueta

                };

                db.Gastos.Add(aux);
                db.SaveChanges();
                return true;
            }
        }


        private Data.Etiquetas CrearEtiquetas(string etiquetas, AplicacionesEntities db)
        {
            try
            {
                string[] et = etiquetas.Trim().Split('#');
                var categoria = et.Length > 1 ? et[1] : "";
                var seccion = et.Length > 2 ? et[2] : "";

                if (categoria == "")
                    throw new Exception("No encontrado ninguna etiqueta válida");


                var etiqueta = BuscaroInsertar(categoria, null, db);

                if (et.Length > 2)
                {
                    return BuscaroInsertar(seccion, etiqueta.IdEtiqueta, db);
                }
                else
                    return etiqueta;



            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Data.Etiquetas BuscaroInsertar(string categoria, int? seccion, AplicacionesEntities db)
        {

            IQueryable<Data.Etiquetas> etiquetaprincipal;

            if (seccion == null)
                etiquetaprincipal = from b in db.Etiquetas
                                    where b.Descorta == categoria && b.IdSeccion==null
                                    select b;
            else

                etiquetaprincipal = from b in db.Etiquetas
                                    where b.Descorta == categoria && b.IdSeccion == seccion.Value
                                    select b;

            if (etiquetaprincipal.FirstOrDefault() == null)
            {
                var principal = new Data.Etiquetas
                {
                    Descorta = categoria
                };

                if (seccion.HasValue)
                    principal.IdSeccion = seccion.Value;

                db.Etiquetas.Add(principal);
                db.SaveChanges();
                return principal;


            }
            return etiquetaprincipal.First();

        }
    }
}
