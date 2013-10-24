using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActivosMvc.Utils;
using ActivosMvc.Modelo;

namespace ActivosMvc.DAO
{
    public class AlmacenDAO : GenericDAO<Almacen>
    {
        private static AlmacenDAO instance = null;

        private AlmacenDAO() { }

        public static AlmacenDAO getInstance()
        {
            if (instance == null)
                instance = new AlmacenDAO();
            return instance;
        }

        public List<Almacen> getList()
        {
            return base.getList("Almacen");
        }
    }
}