using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using ActivosMvc.Modelo;
using ActivosMvc.Services;

namespace ActivosMVC.Controllers
{
    public class ConfiguracionController : Controller
    {
        private static CatalogosServices catalogosService = new CatalogosServices();
        private ActivoServices activoService = new ActivoServices();
        //
        // GET: /Configuracion/

        public ActionResult Index()
        {
            return View("Configuracion");
        }

        [HttpPost]
        public ActionResult Save(Activo activo) {
            string msg = "";
            bool exito = activoService.saveOrUpdate(activo);
            if (exito) {
                msg = "Guardado exitoso";
            } else {
                msg = "Error al guardar";
            }
            return Json(msg);
        }

        [HttpPost]
        public ActionResult Search(int id) {
            Activo activo = activoService.findById(id);
            if (activo != null)
                return Json(activo);
            return Json("No se encontró el registro");
        }

        [WebMethod]
        public ActionResult CargarAlmacenes() {
            List<Almacen> almacenes = catalogosService.getListadoAlmacenes();
            return Json(almacenes);
        }
    }
}
