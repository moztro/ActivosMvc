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
    public class ConsultasController : Controller
    {
        private ActivoServices activoService = new ActivoServices();
        private static CatalogosServices catalogoService = new CatalogosServices();

        //
        // GET: /Consultas/

        public ActionResult Index(){
            return View("Consultas");
        }

        [HttpGet]
        public ActionResult GetActivos(int id) {
            List<Activo> activos = activoService.getListActivos(id);
            return Json(activos, JsonRequestBehavior.AllowGet);
        }

        [WebMethod]
        public ActionResult CargarCombo() {
            List<Almacen> almacenes = catalogoService.getListadoAlmacenes();            
            return Json(almacenes);
        }
    }
}
