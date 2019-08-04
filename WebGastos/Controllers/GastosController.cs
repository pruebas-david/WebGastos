using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGastos.Models;

namespace WebGastos.Controllers
{
    public class GastosController : Controller
    {
        // GET: Gastos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        [HttpPost]
        public ActionResult Create(Gasto param)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //buscar etiqueta o crearlas
                  
                    using (AplicacionesEntities1 db = new AplicacionesEntities1())
                    {
                        var e = CrearEtiquetas(param.Etiquetas,db);


                        if (param.Fecha == null)
                            param.Fecha = DateTime.UtcNow;

                       
                        var aux = new Data.Gastos
                        {
                            Descorta = param.Descorta,
                            Fecha = param.Fecha.Value,
                            Importe = float.Parse(param.Importe.Replace('.', ',')),
                            IdEtiqueta= e.IdEtiqueta
                            
                        };
                        
                        db.Gastos.Add(aux);
                        db.SaveChanges();
                   }

                    return RedirectToAction("Index");
                }

                else
                    return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        private Data.Etiquetas CrearEtiquetas(string etiquetas, AplicacionesEntities1 db)
        {
            try{
                string[] et= etiquetas.Trim().Split('#');
                var categoria = et.Length>1 ? et[1] :"";
                var seccion = et.Length>2 ? et[2]: "";

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

        private Data.Etiquetas BuscaroInsertar(string categoria, int? seccion, AplicacionesEntities1 db)
        {

            IQueryable<Data.Etiquetas> etiquetaprincipal;

            if (seccion==null)
              etiquetaprincipal = from b in db.Etiquetas
                                    where b.Descorta == categoria
                                    select b;
            else

               etiquetaprincipal = from b in db.Etiquetas
                                    where b.Descorta == categoria && b.IdSeccion==seccion.Value
                                    select b;

            if (etiquetaprincipal.FirstOrDefault() == null)
            {
                var principal = new Etiquetas
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

        // GET: Gastos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gastos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
