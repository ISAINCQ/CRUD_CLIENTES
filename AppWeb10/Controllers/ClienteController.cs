using AppWeb10.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Negocio;

namespace AppWeb10.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            var obj = new ClienteNegocio();
            var est = obj.getClientes();
            var lst = new List<ClienteModel>();

            foreach(var item in est)
            {
                var cliente = new ClienteModel();
                cliente.IdCliente = item.IdCliente;
                cliente.Nombre = item.Nombre;
                cliente.Edad = item.Edad;
                cliente.FechaNacimiento = item.FechaNacimiento;
                cliente.MayorEdad = item.MayorEdad;
                lst.Add(cliente);
            }

            return View(lst);
        }
        public IActionResult DeleteCliente(int IdCliente)
        {
            var obj = new ClienteNegocio();
            var est = obj.DeleteCliente(IdCliente);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCliente(int IdCliente)
        {
            var obj = new ClienteNegocio();
            var est = obj.getClienteById(IdCliente);
            var model = new ClienteModel();

            model.IdCliente = est.IdCliente;
            model.Nombre = est.Nombre;
            model.Edad = est.Edad;
            model.FechaNacimiento = est.FechaNacimiento;
            model.MayorEdad= est.MayorEdad;

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCliente(ClienteModel model, int IdCliente)
        {
            var obj = new ClienteNegocio();
            var entity = new ClienteEntity();

            entity.IdCliente = IdCliente;
            entity.Nombre = model.Nombre;
            entity.Edad = model.Edad;
            entity.FechaNacimiento = model.FechaNacimiento;
            entity.MayorEdad = model.MayorEdad;

            var est = obj.UpdateCliente(entity);
            ViewData["estado"] = est;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult InsertCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertCliente(ClienteModel model)
        {
            var obj = new ClienteNegocio();
            var cliente = new ClienteEntity();

            cliente.Nombre = model.Nombre;
            cliente.Edad = model.Edad;
            cliente.FechaNacimiento = model.FechaNacimiento;
            cliente.MayorEdad = cliente.MayorEdad;

            var est = obj.InsertCliente(cliente);
            ViewData["estado"] = est;
            return RedirectToAction("Index");
        }
    }
}
