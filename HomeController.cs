using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo01.Librerias.EntidadesNegocio;
using Demo01.Librerias.ReglasNegocio;

namespace Demo01.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TablaProductos()
        {
            return PartialView("TablaProductos");
        }

        public ActionResult Categorias()
        {
            brCategoria bl = new brCategoria();
            var lista = bl.Listar();

            return PartialView("TablaCategorias", lista);
        }

        public ActionResult Employees(string filtro)
        {
            brEmpleado bl = new brEmpleado();
            var lista = bl.Filtrar(filtro ?? "");

            return PartialView("TablaEmpleados", lista);
        }

        brCliente bl = new brCliente();

        public ActionResult Customers(int page = 1)
        {
            var data = bl.ListarPaginado(page, 10);
            ViewBag.Total = data.Item2;
            ViewBag.Page = page;
            ViewBag.PageSize = 10;

            return PartialView("TablaClientes", data.Item1);
        }

        [HttpPost]
        public ActionResult RegistraCliente(beCliente c)
        {
            bl.Insertar(c);
            return Json("OK");
        }

        [HttpPost]
        public ActionResult ActualizaCliente(beCliente c)
        {
            bl.Actualizar(c);
            return Json("OK");
        }

        [HttpPost]
        public ActionResult EliminaCliente(string id)
        {
            bl.Eliminar(id);
            return Json("OK");
        }
    }
}