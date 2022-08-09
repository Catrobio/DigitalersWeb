using DigitalerWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DigitalerWeb.Controllers
{
    public class ClientesController : Controller
    {
        // GET: ClientesController1
        //Creo una variable global privada
        public List<Clientes> _clientes;
        public ClientesController()
        {
            //Instacio lista de clase clientes
            _clientes = new List<Clientes>();
            //Instancio y agrego valor a Clientes
            var cliente = new Clientes
            {
                Id = 1,
                Nombre = "Ignacio",
                Apellido = "Pacheco",
                Documento = "123456"
            };

            _clientes.Add(cliente);

            var cliente2 = new Clientes
            {
                Id = 2,
                Nombre = "Francisco",
                Apellido = "Alvarez",
                Documento = "456789"
            };

            _clientes.Add(cliente2);
        }
        public ActionResult Index()
        {            
            //envio lista a la vista
            return View(_clientes);
            
        }

        // GET: ClientesController1/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clientes.Where(c => c.Id == id).FirstOrDefault();
            return View(cliente);
        }

        // GET: ClientesController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController1/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Clientes cliente)
        {
            try
            {
                _clientes.Add(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController1/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clientes.Where(c => c.Id == id).FirstOrDefault();
            return View(cliente);
        }

        // POST: ClientesController1/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Clientes cliente)
        {
            try
            {
                var clienteEdit = _clientes.Where(c => c.Id == cliente.Id).FirstOrDefault();
                
                _clientes.Remove(clienteEdit);

                _clientes.Add(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController1/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clientes.Where(c => c.Id == id).FirstOrDefault();
            return View(cliente);
        }

        // POST: ClientesController1/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var cliente = _clientes.Where(c => c.Id == id).FirstOrDefault();
                _clientes.Remove(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
