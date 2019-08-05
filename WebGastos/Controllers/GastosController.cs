
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public ActionResult Create(Modelos.GastoModel param)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Bussines.BussinesGastos g =new Bussines.BussinesGastos();
                    if (g.Ejecutar(param))
                        return RedirectToAction("Index");
                    else
                        return View();
                }

                else
                    return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // POST: Gastos/Graficos
        [HttpGet]
        public ActionResult Graficos(string tipo)
        {
            try
            {
                if (tipo == null) tipo = "y";

                string texto;
                string texto2;

                switch (tipo)
                {
                    case "m":
                        texto = "mensual";
                        texto2 = "mes";
                        break;
                    case "d":
                        texto = "diario";
                        texto2 = "dia";
                        break;
                    default:
                        texto = "anual";
                        texto2 = "año";
                        break;
                }
                Bussines.BussinesDatos g = new Bussines.BussinesDatos();
                var aux = g.Ejecutar(tipo);

                Highcharts columnChart = new Highcharts("columnchart");

                columnChart.InitChart(new Chart()
                {
                    Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                    BackgroundColor = new BackColorOrGradient(System.Drawing.Color.AliceBlue),
                    Style = "fontWeight: 'bold', fontSize: '17px'",
                    BorderColor = System.Drawing.Color.LightBlue,
                    BorderRadius = 0,
                    BorderWidth = 2

                });

                columnChart.SetTitle(new Title()
                {
                    Text = "Acumulación de gastos " + texto
                }); ;

                //columnChart.SetSubtitle(new Subtitle()
                //{
                //    Text = "Played 9 Years Together From 2004 To 2012"
                //});


                string[] datosX = new string[aux.Count()];
                int j = 0;
                foreach (var item in aux)
                {
                    datosX[j] = item.agrupacion.ToString();
                    j++;
                }
                columnChart.SetXAxis(new XAxis()
                {
                    Type = AxisTypes.Category,
                    Title = new XAxisTitle() { Text = texto2, Style = "fontWeight: 'bold', fontSize: '17px'" },
                    Categories = datosX
                }) ;

                columnChart.SetYAxis(new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = "Importe",
                        Style = "fontWeight: 'bold', fontSize: '17px'"
                    },
                    ShowFirstLabel = true,
                    ShowLastLabel = true,
                    Min = 0
                });

                columnChart.SetLegend(new Legend
                {
                    Enabled = true,
                    BorderColor = System.Drawing.Color.CornflowerBlue,
                    BorderRadius = 6,
                    BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
                });


                Series[] datos = new Series[aux.Count];
                var i = 0;
                foreach (var item in aux)
                {

                    datos[i] = new Series
                    {
                        Name = item.etiqueta,
                        Data = new Data(new object[] { item.dato })
                    };
                i++;

                }

                columnChart.SetSeries(datos);


                return View(columnChart);
                  
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
