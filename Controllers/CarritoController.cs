using Gerencia_Proyectos_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gerencia_Proyectos_.Controllers
{

    public class CarritoController : Controller
    {
        // GET: AgregarCarrito
        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.IDProd == id)
                    return i;
            }
            return -1;
        }
        private gp_CafeteriaEntities ce = new gp_CafeteriaEntities();
        public ActionResult AgregarCarrito(int ID)
        {

            if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(ce.MenuProductos.Find(ID), 1));
                Session["carrito"] = compras;

            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = getIndex(ID);
                if (IndexExistente == -1)
                    compras.Add(new CarritoItem(ce.MenuProductos.Find(ID), 1));
                else
                    compras[IndexExistente].Cantidad++;
                Session["carrito"] = compras;
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return View("AgregarCarrito");
        }
        public ActionResult FinalizaCompra()
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            if (compras != null && compras.Count > 0)
            {
                OrdenPedidos venta = new OrdenPedidos();
                venta.Estado = "1";
                venta.IdMesa = Convert.ToInt32(Session["Mesa"]);
                venta.Total = compras.Sum(x => x.Producto.PrecioProd * x.Cantidad);
                venta.IdOrden = 0;
                venta.Fecha = DateTime.Now;
                venta.Descrpción = "sssss";
                venta.Cantidad = 1;
                venta.CodProd = "a";
                venta.IDProd = 2;

                ce.OrdenPedidos.Add(venta);
                ce.SaveChanges();
            }
            return View();
        }


    }

    
}