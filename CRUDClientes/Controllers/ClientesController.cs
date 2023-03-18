using Microsoft.AspNetCore.Mvc;

using CRUDClientes.Servicios;
using CRUDClientes.Models;

namespace CRUDClientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IServicio_Api _servicioApi;

        public ClientesController(IServicio_Api servicioApi)
        {
            _servicioApi = servicioApi;
        }
        public async Task<IActionResult> Index()
        {
            List<Clientes> lista = await _servicioApi.Lista();
            return View(lista);
        }
        public async Task<IActionResult> Clientes(string Identificacion)
        {
            Clientes modeloClientes = new Clientes();
            ViewBag.Accion = "Nuevo";


            if (!string.IsNullOrEmpty(Identificacion))
            {
                modeloClientes = await _servicioApi.Obtener(Identificacion);
                ViewBag.Accion = "Editar";
            }
            return View(modeloClientes);
        }
        [HttpPost]
        public async Task<IActionResult> Guardar(Clientes objCliente)
        {
            Clientes modeloClientes = new Clientes();
            modeloClientes = await _servicioApi.Obtener(objCliente.Identificacion);

            bool respuest;
            if (string.IsNullOrEmpty(modeloClientes.Identificacion))
            {
                respuest = await _servicioApi.Guardar(objCliente);
            }
            else
            {
                respuest = await _servicioApi.Editar(objCliente);
            }
            if (respuest)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(string Identificacion)
        {
            var respuesta = await _servicioApi.Eliminar(Identificacion);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
    }
}