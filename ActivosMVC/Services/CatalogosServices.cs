using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosMvc.Modelo;
using ActivosMvc.DAO;

namespace ActivosMvc.Services
{
    public class CatalogosServices
    {
        public List<Almacen> getListadoAlmacenes()
        {
            return AlmacenDAO.getInstance().getList();
        }
    }
}