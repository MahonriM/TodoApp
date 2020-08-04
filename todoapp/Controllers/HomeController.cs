using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using todoapp.Models;
namespace todoapp.Controllers
{
    public class HomeController : Controller
    {
        Itarea repotarea = new TareaRepositorio();

        public ActionResult Index()
        {
            return View(repotarea.MostrarTareas());
        }
        public ActionResult Create()
        {
            List<Tarea> Lsttarea;
            Lsttarea = repotarea.MostrarTareas();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tarea tra)
        {
            repotarea.agregarTarea(tra);  
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            List<Tarea> Lsttarea;
            Lsttarea = repotarea.MostrarTareas();
            return View(repotarea.obtenertarea(id));
        }
        [HttpPost]
        public ActionResult Edit(int id,Tarea tra)
        {
            tra.id = id;
            repotarea.ActualizarTask(tra);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Tarea tareas = (repotarea.obtenertarea(id));
             return View(tareas);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection frm)
        {
            repotarea.eliminarTarea(id);
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}