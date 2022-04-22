using Gerencia_Proyectos_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gerencia_Proyectos_.Controllers
{
    public class PagarController : Controller
    {
        // GET: Pagar
        private gp_CafeteriaEntities db = new gp_CafeteriaEntities();
        
        public ActionResult Index()
        {
            int id = 0; 
            string Estado = "1";
            int IdMesa = 0;
            decimal Total = 0;
            int IdOrden = 0;
            DateTime Fecha = DateTime.Now;
            string Descrpción = "sssss";
            int Cantidad = 1;
            string CodProd = "a";
            int IDProd = 2;
            string query = "Select* from OrdenPedidos where IdMesa = "+Session["mesa"]+" and estado = 1";
            //OrdenPedidos department = db.OrdenPedidos.SqlQuery(query);
            IEnumerable<OrdenPedidos> data = db.OrdenPedidos.SqlQuery(query);
            data.ToList();
            foreach (OrdenPedidos a in data)
            {
                if(a.Estado == "1")
                {
                    a.Estado = "0";
                }

            }
                    db.SaveChanges();
            OrdenPedidos venta = new OrdenPedidos();
            venta.Estado = "0";
            venta.IdMesa = IdMesa;
            venta.Total = Total;
            venta.Fecha = Fecha;
            venta.Descrpción = Descrpción;
            venta.Cantidad = Cantidad;
            venta.CodProd = CodProd;
            venta.IDProd = IDProd;
            venta.IdOrden = IdOrden;
            

            return Redirect("/mesas");
        }
    }
}