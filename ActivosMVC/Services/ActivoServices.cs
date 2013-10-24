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
            return ActivoDAO.getInstance().saveOrUpdate(activo);
        }

        public Activo findById(int id)
        {
            return ActivoDAO.getInstance().get(id);
        }
    }
}