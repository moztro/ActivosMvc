using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosMvc.Modelo;
using ActivosMvc.DAO;

namespace ActivosMvc.Services
{
    public class ActivoServices
    {
        public bool saveOrUpdate(Activo activo)
        {
            try {
                activo.Folio = activo.Almacen.Descripcion.Substring(0, 1).ToUpper() + "";
            } catch {
                activo.Folio = "XXXXX";
            }
            return ActivoDAO.getInstance().saveOrUpdate(activo);
        }

        public Activo findById(int id)
        {
            return ActivoDAO.getInstance().get(id);
        }

        public List<Activo> getListActivos() {
            return ActivoDAO.getInstance().getList();
        }

        public List<Activo> getListActivos(int almacenId) {
            return ActivoDAO.getInstance().getActivosXAlmacen(almacenId);
        }
    }
}