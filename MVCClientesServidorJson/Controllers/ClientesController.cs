using MVCClientesServidorJson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCClientesServidorJson.Controllers
{
    public class ClientesController : Controller
    {
        ModeloClientes modelo;
        public ClientesController()
        {
            this.modelo = new ModeloClientes();
        }
        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            List<Cliente> clientes =
                await modelo.GetCliente();
            return View(clientes);
        }

        [HttpPost]
        public async Task<ActionResult> Index(int? idcliente)
        {

            Cliente cliente =
                 await modelo.BuscarCliente(idcliente.GetValueOrDefault());
            if (cliente == null)
            {
                return View();
            }
            else
            {
                List<Cliente> clientes = new List<Cliente>();
                clientes.Add(cliente);
                return View(clientes);
            }
            

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            await modelo.InsertarCliente(cliente.IdCliente, cliente.Nombre
                , cliente.PaginaWeb, cliente.Imagen);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            Cliente cli = await modelo.BuscarCliente(id);
            return View(cli);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Cliente cliente)
        {
            await modelo.ModificarCliente(cliente.IdCliente, cliente.Nombre
                , cliente.PaginaWeb, cliente.Imagen);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await modelo.EliminarCliente(id);
            return RedirectToAction("Index");
        }


        //[Route("Delete/{id}")]
        //[HttpPost]
        //public async Task<ActionResult> ActionResult(int id)
        //{

        //}


    }
}