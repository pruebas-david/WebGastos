﻿using Data;
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
                using (AplicacionesEntities db =new AplicacionesEntities())
                {
                    if (param.Fecha == null)
                        param.Fecha = DateTime.UtcNow;

                    db.Gastos.Add(new Data.Gastos
                    {
                        Descorta = param.Descorta,
                        Deslarga = param.Deslarga,
                        Fecha = param.Fecha.Value,
                        Importe = param.Importe
                    });

                    db.SaveChanges();
          
                }


                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
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
