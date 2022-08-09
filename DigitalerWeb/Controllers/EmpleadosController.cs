using DigitalersLib.Operaciones;
using DigitalersLib.Modelos;
using DigitalerWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpleadosModels = DigitalerWeb.Models.Empleados;

namespace DigitalerWeb.Controllers
{
    public class EmpleadosController : Controller
    {
        public List<DigitalersLib.Modelos.Empleados> _empleadosLibs;
        public Operarios _operarios;
        public List<EmpleadosModels> _empleadosWeb;
        public EmpleadosController()
        {
            _operarios = new Operarios();

            _empleadosLibs = _operarios.GetEmpleados();
            
            _empleadosWeb = new List<EmpleadosModels>();

            //por cada empleado de lib creamos un empleado de el model web
            foreach (var empleadosLib in _empleadosLibs)
            {
                var empleado = new EmpleadosModels
                {
                    Id = empleadosLib.Id,
                    Nombre = empleadosLib.Nombre,
                    FechaIngreso = empleadosLib.FechaIngreso
                };

                _empleadosWeb.Add(empleado);
            }

        }
        // GET: EmpleadosController
        public ActionResult Index()
        {
            return View(_empleadosWeb);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
