﻿using SaberesySoluciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaberesySoluciones.Controllers
{
    public class ClasesController : Controller
    {
        // GET: Clases
        public ActionResult Index()
        {
            ViewBag.title = "Vista Clases";
            var clases = new Clase().ListarClases();
            return View(clases);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            Clase clase = new Clase();
            clase.fecha = DateTime.Today;
            return View(clase);
        }

        [HttpPost]
        public ActionResult Crear(Clase nueva)
        {
            nueva.Crear();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Eliminar(long id)
        {
            Clase clase = new Clase();
            clase.Seleccionar(id);
            return View(clase);
        }

        [HttpPost]
        public ActionResult Eliminar(Clase c)
        {
            c.EliminarSucursal(c.codigo);
            return RedirectToAction("Index");
        }
    }
}